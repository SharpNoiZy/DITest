using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.CQRS.Contracts
{
	public interface IQueryDispatcher
	{
		Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
			where TParameter : IQuery
			where TResult : IQueryResult;
	}
}