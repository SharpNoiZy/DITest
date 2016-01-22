using MFT.Core.CQRS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MFT.Core.CQRS.Contracts;


namespace MFT.Core.CQRS
{
	public class QueryDispatcher : IQueryDispatcher
	{
		private IServiceProvider _provider;


		public QueryDispatcher(IServiceProvider provider)
		{
			_provider = provider;
		}


		public async Task<TResult> Dispatch<TParameter, TResult>(TParameter query)
			where TParameter : IQuery
			where TResult : IQueryResult
		{
			var queryHandler = _provider.GetService<IHandleQuery<TParameter, TResult>>();

			return await queryHandler.Retrieve(query);
		}
	}
}