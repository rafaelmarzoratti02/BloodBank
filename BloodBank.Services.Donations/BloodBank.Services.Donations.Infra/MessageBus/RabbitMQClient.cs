//using MongoDB.Bson.IO;
//using Newtonsoft.Json;
//using Newtonsoft.Json.Serialization;
//using RabbitMQ.Client;
//using System.Text;

//namespace BloodBank.Services.Donations.Infra.MessageBus;

//public class RabbitMQClient : IMessageBusClient
//{
//    private readonly IConnection _connection;

//    public RabbitMQClient(ProducerConnection producerConnection)
//    {
//        _connection = producerConnection.Connection;
//    }

//    public async Task PublishAsync(object message, string routingKey, string exchange)
//    {
//        var channel = await _connection.CreateChannelAsync();

//        var settings = new JsonSerializerSettings
//        {
//            NullValueHandling = NullValueHandling.Ignore,
//            ContractResolver = new CamelCasePropertyNamesContractResolver()
//        };

//        var payload = Newtonsoft.Json.JsonConvert.SerializeObject(message, settings);
//        var body = Encoding.UTF8.GetBytes(payload);

//        await channel.BasicPublishAsync(exchange, routingKey, body);
//    }
//}
