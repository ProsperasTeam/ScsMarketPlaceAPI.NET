﻿using System;
namespace UserService.Services
{
	public interface IMessageProducer
	{
        public void SendingMessage<T>(T message);
	}
}

