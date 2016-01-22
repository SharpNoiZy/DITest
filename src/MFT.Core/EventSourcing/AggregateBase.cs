using MFT.Core.CQRS;
using MFT.Core.EventSourcing.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace MFT.Core.EventSourcing
{
	public abstract class AggregateBase<TState> : IAggregateRoot, IEventSourced where TState : class
	{
		public Guid Id { get; protected set; }

		public int Version { get; internal set; }

		public List<IEvent> Changes { get; private set; }

		protected TState State;

		private IEventStore _eventStore;


		public AggregateBase(IEventStore eventStore)
		{
			Version = 0;
			Changes = new List<IEvent>();
			State = Activator.CreateInstance<TState>();

			_eventStore = eventStore;
		}


		public void LoadByHistory(List<IEvent> pastEvents)
		{
			foreach (var e in pastEvents)
			{
				ApplyChange(e, false);
			}
		}


		protected void ApplyChange(IEvent e)
		{
			ApplyChange(e, true);
		}


		private void ApplyChange(IEvent e, bool isNew)
		{
			(this as dynamic).Apply((dynamic)e);

			e.AggregateId = Id;
			e.Version = Version + 1;

			if (isNew == true)
			{
				Changes.Add(e);
				Save();
			}
		}


		private void Save()
		{
			_eventStore.SaveEvents(Id, Changes, Version);
		}




		/*protected void Handles<TEvent>(Action<TEvent> handler) where TEvent : IEvent
		{
			this.handlers.Add(typeof(TEvent), @event => handler((TEvent)@event));
		}

		protected void LoadFrom(IEnumerable<IVersionedEvent> pastEvents)
		{
			foreach (var e in pastEvents)
			{
				this.handlers[e.GetType()].Invoke(e);
				this.version = e.Version;
			}
		}

		protected void Update(VersionedEvent e)
		{
			e.SourceId = this.Id;
			e.Version = this.version + 1;
			this.handlers[e.GetType()].Invoke(e);
			this.version = e.Version;
			this.pendingEvents.Add(e);
		}*/
	}
}
