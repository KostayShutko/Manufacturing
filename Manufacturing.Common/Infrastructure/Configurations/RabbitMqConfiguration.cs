﻿namespace Manufacturing.Common.Infrastructure.Configurations
{
    public class RabbitMqConfiguration
    {
        public string HostName { get; set; }
        public string ExchangeName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public ushort Port { get; set; }
    }
}
