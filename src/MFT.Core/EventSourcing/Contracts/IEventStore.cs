using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing.Contracts
{
	public interface IEventStore
	{
		void SaveEvents(Guid aggregateId, IEnumerable<IEvent> events, int expectedVersion);


		List<IEvent> GetEventsForAggregate(Guid aggregateId, int fromVersion = 0);
	}
}