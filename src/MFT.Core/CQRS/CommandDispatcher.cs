using MFT.Core.CQRS;
using MFT.Core.CQRS.Contracts;
using MFT.Core.EventSourcing.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.CQRS
{
	public class CommandDispatcher : ICommandDispatcher
	{
		private IServiceProvider _provider;


		public CommandDispatcher(IServiceProvider provider)
		{
			_provider = provider;
		}


		public void Dispatch<TCommand>(TCommand command) where TCommand : class, ICommand
		{
			IHandleCommand<TCommand> commandHandler = _provider.GetService<IHandleCommand<TCommand>>();

			commandHandler.Handle(command);
		}


		public void Dispatch<TCommand>(Guid aggregateId, TCommand command) where TCommand : class, ICommand
		{
			IHandleCommand<TCommand> commandHandler = _provider.GetService<IHandleCommand<TCommand>>();

			// Load events for the given aggregate and apply them to the new instance
			IEventStore eventStore = _provider.GetService<IEventStore>();
			((IAggregateRoot)commandHandler).LoadByHistory(eventStore.GetEventsForAggregate(aggregateId));

			commandHandler.Handle(command);
		}
	}
}