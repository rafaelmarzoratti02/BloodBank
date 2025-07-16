using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Infra.MessageBus
{
    public class BasicPublishOptions
    {
        public BasicPublishOptions(string exchange, string routingKey, byte[] body)
        {
            Exchange = exchange;
            RoutingKey = routingKey;
            Body = body;
        }

        public string Exchange { get; set; }
        public string RoutingKey { get; set; }
        public byte[] Body { get; set; }
    }
}
