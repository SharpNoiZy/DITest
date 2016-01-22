using MFT.Core.Data.Models;
using MFT.Core.EventSourcing.Contracts;
using MFT.Core.EventSourcing.Exceptions;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Sqlite;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;


namespace MFT.Data
{
	public class EventStoreContext : DbContext, IEventStoreContext
	{
		public DbSet<ExecutedEvent> ExecutedEvents { get; set; }

		private IEventPublisher _eventPublisher { get; set; }


		public EventStoreContext(DbContextOptions options, IEventPublisher eventPublisher) : base(options)
		{
			_eventPublisher = eventPublisher;
			Database.EnsureCreated();
		}


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (optionsBuilder.IsConfigured == false)
			{
				var connectionStringBuilder = new SqliteConnectionStringBuilder { DataSource = "test.db" };
				var connectionString = connectionStringBuilder.ToString();
				var connection = new SqliteConnection(connectionString);

				optionsBuilder.UseSqlite(connection);
			}
		}


		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<ExecutedEvent>().HasKey(x => new { x.AggregateId, x.Version });
		}


		public List<IEvent> GetEventsForAggregate(Guid aggregateId, int fromVersion = 0)
		{
			Dictionary<string, string> eventListAsStrings = ExecutedEvents.Where(x => x.AggregateId == aggregateId).ToList().ToDictionary(x => x.BodyType, x2 => x2.Body);
			List<IEvent> result = new List<IEvent>();


			foreach (var loopObjectAsString in eventListAsStrings)
			{
				Type eventType = Assembly.Load(new AssemblyName(loopObjectAsString.Key.Split('|')[0])).GetType(loopObjectAsString.Key.Split('|')[1]);
				result.Add((IEvent)JsonConvert.DeserializeObject(loopObjectAsString.Value, eventType));
			}


			if (result.Count == 0)
				throw new NoEventsFoundForAggregateException();

			return result;
		}


		public void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int expectedVersion)
		{
			// Load count of events in the eventsore, for the aggregate with the specified id (To compare versions)
			var currentVersionInStore = ExecutedEvents.Count(x => x.AggregateId == aggregateId);


			if (currentVersionInStore != expectedVersion)
				throw new ConcurrencyException();


			var i = expectedVersion;
			foreach (var @event in events)
			{
				i++;

				ExecutedEvents.Add(new ExecutedEvent { AggregateId = aggregateId, Body = JsonConvert.SerializeObject(@event), BodyType = @event.GetType().GetTypeInfo().Assembly.FullName + "|" + @event.GetType().FullName, Executed = DateTime.UtcNow, Version = i });
				SaveChanges();

				_eventPublisher.Publish(@event);
			}
		}
	}
}
