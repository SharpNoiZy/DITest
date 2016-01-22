using MFT.Core.EventSourcing.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;


namespace MFT.Core.EventSourcing
{
	public class EventPublisher : IEventPublisher
	{
		private IServiceProvider _provider;


		public EventPublisher(IServiceProvider provider)
		{
			_provider = provider;
		}


		public void Publish<TEvent>(TEvent @event) where TEvent : class, IEvent
		{
			List<ISubscribeOn<TEvent>> eventHandler = _provider.GetServices<ISubscribeOn<TEvent>>().ToList();

			foreach (var loopEventHandler in eventHandler)
			{
				loopEventHandler.Handle(@event);
			}
		}
	}
}
