using MFT.Core.EventSourcing.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models
{
	public class ExecutedEvent
	{
		public Guid AggregateId { get; set; }

		public string Body { get; set; }

		public string BodyType { get; set; }

		public int Version { get; set; }

		public DateTime Executed { get; set; }
	}
}
