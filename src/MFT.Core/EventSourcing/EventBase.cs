using MFT.Core.EventSourcing.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing
{
	public abstract class EventBase : IEvent
	{
		public Guid AggregateId { get; set; }


		public int Version { get; set; }
	}
}