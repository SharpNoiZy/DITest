using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.CQRS.Contracts
{
	public interface IHandleQuery<TParameter, TResult>
	   where TResult : IQueryResult
	   where TParameter : IQuery
	{
		Task<TResult> Retrieve(TParameter query);
	}
}