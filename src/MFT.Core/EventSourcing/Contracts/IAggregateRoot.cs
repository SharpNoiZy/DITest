using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing.Contracts
{
	public interface IAggregateRoot
	{
		Guid Id { get; }


		void LoadByHistory(List<IEvent> pastEvents);
	}
}