using System;
namespace AuthenticationService.Services
{
	public interface IMessageProducer
	{
        public void SendingMessage<T>(T message);
	}
}

