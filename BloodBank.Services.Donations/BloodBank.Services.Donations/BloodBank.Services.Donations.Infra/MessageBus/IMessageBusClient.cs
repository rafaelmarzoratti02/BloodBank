using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBank.Services.Donations.Infra.MessageBus;

public interface IMessageBusClient
{
    public Task PublishAsync(object message, string routingKey, string exchange);
}
