using MFT.Integration.UserApi.Aggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MFT.Integration.UserApi.Commands;
using MFT.Core.EventSourcing.Contracts;
using Xunit;
using MFT.Core.CQRS.Contracts;
using Test.MFT.Integration.Helper;
using MFT.Core.Data.Models;

namespace Test.MFT.Integration.UserApi
{
	public class when_creating_an_new_user : SpecificationBase<UserAggregate>
	{
		private ICommandDispatcher _commandDispatcher;

		private IEventStore _eventStore;

		private IReadModelContext _readContext;

		private Guid _newUserId;


		public when_creating_an_new_user()
		{

		}


		protected override void Given()
		{
			_commandDispatcher = DependencyHelper.Provider.GetService<ICommandDispatcher>();
			_eventStore = DependencyHelper.Provider.GetService<IEventStore>();
			_readContext = DependencyHelper.Provider.GetService<IReadModelContext>();
			_newUserId = Guid.NewGuid();
		}


		protected override void When()
		{
			_commandDispatcher.Dispatch(new CreateUser(_newUserId, "when_creating_an_new_user", "when_creating_an_new_user", "test@test.de", "Tolle Timezone", "Admin"));
		}


		[Then]
		public void it_should_exist_in_the_event_store()
		{
			List<IEvent> pastEvents = _eventStore.GetEventsForAggregate(_newUserId);

			Assert.Equal(1, pastEvents.Count());
		}


		[Then]
		public void it_should_exist_in_the_user_table()
		{
			int userCount = _readContext.Set<User>().Count();

			Assert.Equal(1, userCount);
		}
	}
}