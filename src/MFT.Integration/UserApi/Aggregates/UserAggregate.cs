using MFT.Core.CQRS.Contracts;
using MFT.Core.Data;
using MFT.Core.EventSourcing;
using MFT.Core.States;
using MFT.Integration.UserApi.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using MFT.Integration.UserApi.Events;
using MFT.Core.EventSourcing.Contracts;
using MFT.Core.Data.Models;
using Common.Cryptography;
using MFT.Core.CQRS;
using MFT.Core.Aggregates;


namespace MFT.Integration.UserApi.Aggregates
{
	public class UserAggregate : AggregateBase<UserState>,
		IHandleCommand<CreateUser>,
		IApplyEvent<UserCreated>
	{
		private IReadModelContext _readContext;


		public UserAggregate(IReadModelContext readContext, IEventStore eventStore) : base(eventStore)
		{
			_readContext = readContext;
		}


		public void Handle(CreateUser command)
		{
			var dbResult = from user in _readContext.Set<User>() where user.Username == command.Username select user;


			if (dbResult.Count() > 0)
				throw new Exception("There is already a user with this username.");


			string hashedPassword = Crypto.Sha512Hash(command.Password);

			ApplyChange(new UserCreated(command.Id, command.Username, hashedPassword, command.EMail, command.Timezone, command.UserRole));
		}


		public void Apply(UserCreated domainEvent)
		{
			Id = domainEvent.Id;
			State.Username = domainEvent.Username;
			State.PasswordHash = domainEvent.Password;
			State.Email = domainEvent.EMail;
			State.Timezone = domainEvent.Timezone;
		}
	}
}