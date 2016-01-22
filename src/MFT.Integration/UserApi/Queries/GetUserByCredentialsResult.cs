using MFT.Core.CQRS.Contracts;
using MFT.Core.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration.UserApi.Queries
{
	public class GetUserByCredentialsResult : IQueryResult
	{
		public User User { get; set; }
	}
}