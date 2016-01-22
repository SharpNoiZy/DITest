using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MFT.Core.EventSourcing.Contracts
{
	/// <summary>
	/// Represents an identifiable entity that is event sourced.
	/// </summary>
	public interface IEventSourced
	{
		/// <summary>
		/// Gets the entity identifier.
		/// </summary>
		Guid Id { get; }

		/// <summary>
		/// Gets the entity's version. As the entity is being updated and events being generated, the version is incremented.
		/// </summary>
		Int32 Version { get; }

		/// <summary>
		/// Gets the collection of new events since the entity was loaded, as a consequence of command handling.
		/// </summary>
		List<IEvent> Changes { get; }
	}
}
