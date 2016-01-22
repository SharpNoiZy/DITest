using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.EventSourcing.Contracts
{
	public interface IEventStoreContext : IEventStore
	{
		DbSet<TEntity> Set<TEntity>() where TEntity : class;
	}
}