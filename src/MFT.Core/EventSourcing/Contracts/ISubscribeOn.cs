using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFT.Core.EventSourcing.Contracts
{
	/// <summary>
	///     Subscribes on a domain event
	/// </summary>
	/// <typeparam name="T">Domain event type</typeparam>
	/// <remarks>
	///     Read the interface name as <c>I Subscribe On "TheEventName"</c>.
	/// </remarks>
	public interface ISubscribeOn<in T> where T : class, IEvent
	{
		/// <summary>
		///     Will be invoked when the domain event is published.
		/// </summary>
		/// <param name="domainEvent">Domin event to handle</param>
		void Handle(T domainEvent);
	}
}
