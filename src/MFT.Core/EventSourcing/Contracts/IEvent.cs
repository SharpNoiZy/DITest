using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing.Contracts
{
	public interface IEvent
	{
		/// <summary>
		/// The aggregate id
		/// </summary>
		Guid AggregateId { get; set; }


		int Version { get; set; }
	}
}