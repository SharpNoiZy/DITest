using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Core.States
{
	public class UserState
	{
		public string UserRole { get; set; }

		public string Username { get; set; }

		public string PasswordHash { get; set; }

		public string Email { get; set; }

		public string Timezone { get; set; }
	}
}