using MFT.Core.CQRS;
using MFT.Core.CQRS.Contracts;
using MFT.Core.EventSourcing;
using MFT.Core.EventSourcing.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Scrutor;
using MFT.Integration.UserApi.Aggregates;
using MFT.Integration.UserApi.Queries;
using Microsoft.Data.Entity;
using MFT.Data;
using Xunit;
using MFT.Integration.UserApi.Events;

namespace Test.MFT.Integration.Helper
{
	public class DependencyInjectionFixture : IDisposable
	{
		public DependencyInjectionFixture()
		{
			var db = new DbContextOptionsBuilder();
			db.UseInMemoryDatabase();


			ServiceCollection services = DependencyHelper.Services;

			//services.AddEntityFramework().AddSqlite().AddDbContext<ReadModelContext>(options => { options.UseInMemoryDatabase(); });
			services.AddEntityFramework().AddInMemoryDatabase().AddDbContext<EventStoreContext>(options => { options.UseInMemoryDatabase(); });

			services.AddSingleton<IReadModelContext>(x => { return new ReadModelContext(db.Options); });
			//services.AddSingleton<IEventStore, EventStoreContext>();

			//services.AddSingleton<IReadModelContext>(provider => provider.GetService<ReadModelContext>());
			services.AddSingleton<IEventStore>(provider => provider.GetService<EventStoreContext>());


			// ######################################################################################################
			// CQRS specific IoC code
			services.AddTransient<IQueryDispatcher, QueryDispatcher>();
			services.AddTransient<ICommandDispatcher, CommandDispatcher>();
			services.AddTransient<IEventPublisher, EventPublisher>();


			services.Scan(scan => scan
			   .FromAssemblyOf<UserAggregate>()
					.AddClasses(classes => classes.AssignableTo(typeof(IHandleQuery<,>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime());


			services.Scan(scan => scan
			   .FromAssemblyOf<UserAggregate>()
					.AddClasses(classes => classes.AssignableTo(typeof(IHandleCommand<>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime());


			services.Scan(scan => scan
			   .FromAssemblyOf<UserAggregate>()
					.AddClasses(classes => classes.AssignableTo(typeof(ISubscribeOn<>)))
					.AsImplementedInterfaces()
					.WithScopedLifetime());


			DependencyHelper.Provider = services.BuildServiceProvider();


			/*var hhh = DependencyHelper.Provider.GetService<IEventPublisher>();
			hhh.Publish(new UserCreated(Guid.NewGuid(), "", "", "", "", ""));
			var fff = DependencyHelper.Provider.GetService<ISubscribeOn<UserCreated>>();
			if (fff == null)
			{
				string dasd = "";
			}*/
		}


		public void Dispose()
		{

		}
	}


	[CollectionDefinition("DI collection")]
	public class DependencyInjectionCollection : ICollectionFixture<DependencyInjectionFixture>
	{
		// This class has no code, and is never created. Its purpose is simply
		// to be the place to apply [CollectionDefinition] and all the
		// ICollectionFixture<> interfaces.
	}
}
