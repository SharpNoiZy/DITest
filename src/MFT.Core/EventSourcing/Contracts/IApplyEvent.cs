using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing.Contracts
{
	public interface IApplyEvent<in T> where T : class, IEvent
	{
		/// <summary>
		///	Will be invoked when the domain event is applied to an aggregate.
		/// </summary>
		/// <param name="domainEvent">Domin event to apply</param>
		void Apply(T domainEvent);
	}
}