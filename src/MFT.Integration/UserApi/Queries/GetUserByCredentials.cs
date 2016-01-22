using MFT.Core.CQRS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration.UserApi.Queries
{
	public class GetUserByCredentials : IQuery
	{
		public string Username { get; private set; }

		public string Password { get; private set; }


		public GetUserByCredentials(string username, string password)
		{
			Username = username;
			Password = password;
		}
	}
}