using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.CQRS.Contracts
{
	public interface IHandleCommand<in TCommand> where TCommand : class, ICommand
	{
		void Handle(TCommand command);
	}
}
