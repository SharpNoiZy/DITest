using MFT.Core.CQRS.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration.UserApi.Commands
{
	public class CreateUser : ICommand
	{
		public Guid Id { get; private set; }

		public string Username { get; private set; }

		public string Password { get; private set; }

		public string EMail { get; private set; }

		public string Timezone { get; private set; }

		public string UserRole { get; private set; }


		public CreateUser(Guid id, string username, string password, string email, string timezone, string userRole)
		{
			Id = id;
			Username = username;
			Password = password;
			EMail = email;
			Timezone = timezone;
			UserRole = userRole;
		}
	}
}