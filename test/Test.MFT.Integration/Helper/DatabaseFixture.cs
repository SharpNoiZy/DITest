using Common.Cryptography;
using MFT.Core.CQRS;
using MFT.Core.CQRS.Contracts;
using MFT.Core.Data;
using MFT.Core.Data.Models;
using MFT.Core.EventSourcing;
using MFT.Core.EventSourcing.Contracts;
using MFT.Data;
using Microsoft.Data.Entity;
using Microsoft.Extensions.DependencyInjection;
using Scrutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;


namespace Test.MFT.Integration.Helper
{
	public class DatabaseFixture : IClassFixture<DependencyInjectionFixture>, IDisposable
	{
		public DependencyInjectionFixture DIFixture;


		public DatabaseFixture()
		{
			var readModel = DependencyHelper.Provider.GetService<IReadModelContext>();

			readModel.Set<User>().Add(new User
			{
				UserRole = "Admin",
				Username = "cneuss",
				PasswordHash = Crypto.Sha512Hash("test123"),
				Timezone = "W. Europe Standard Time"
			});
		}


		public void Dispose()
		{
			// ... clean up test data from the database ...
		}
	}

}
