using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.CQRS.Contracts
{
	public interface ICommandDispatcher
	{
		void Dispatch<TParameter>(TParameter command) where TParameter : class, ICommand;

		void Dispatch<TCommand>(Guid aggregateId, TCommand command) where TCommand : class, ICommand;
	}
}