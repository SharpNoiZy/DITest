using MFT.Core.Data;
using MFT.Core.Data.Models;
using MFT.Core.EventSourcing.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MFT.Integration.UserApi.Events
{
	public class UserCreatedHandler : ISubscribeOn<UserCreated>
	{
		private IReadModelContext _readContext;


		public UserCreatedHandler(IReadModelContext readContext)
		{
			_readContext = readContext;
		}


		public void Handle(UserCreated domainEvent)
		{
			// _dataSession.Set<User>()
		}
	}
}