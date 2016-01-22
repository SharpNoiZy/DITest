using MFT.Core.CQRS.Contracts;
using MFT.Core.Data;
using MFT.Core.Data.Models;
using MFT.Core.EventSourcing.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration.UserApi.Queries
{
	public class GetUserByCredentialsHandler : IHandleQuery<GetUserByCredentials, GetUserByCredentialsResult>
	{
		private IReadModelContext _readContext;


		public GetUserByCredentialsHandler(IReadModelContext readContext)
		{
			_readContext = readContext;
		}


		public async Task<GetUserByCredentialsResult> Retrieve(GetUserByCredentials query)
		{
			string hashedPassword = query.Password; // Crypto.Sha512Hash(query.Password);

			//join role in _dataSession.Set<UserRole>() on user.UserRoleId equals role.Id			
			var dbResult = from user in _readContext.Set<User>()
						   where user.Username == query.Username && user.PasswordHash == hashedPassword
						   select user;


			if (dbResult.Count() == 0)
				throw new Exception("No user found with the specified data");


			User tryed = dbResult.First();


			return new GetUserByCredentialsResult { User = tryed };
		}
	}
}