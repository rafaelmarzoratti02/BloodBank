using Microsoft.AspNetCore.Connections;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using Newtonsoft.Json;

namespace BloodBank.Services.Donors.Subscribers;

public class DonationCreatedSubscriber : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private IConnection? _connection;
    private IChannel? _channel;
    private const string Queue = "donor-service/donation-created";
    private const string Exchange = "donor-service";

    public DonationCreatedSubscriber(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await InitializeRabbitMQAsync();

        var consumer = new AsyncEventingBasicConsumer(_channel);
        consumer.ReceivedAsync += async (sender, eventArgs) =>
        {
            var contentArray = eventArgs.Body.ToArray();
            var contentString = Encoding.UTF8.GetString(contentArray);
            var message = JsonConvert.DeserializeObject<DonationCreated>(contentString);

            var result = NotifyDonor(message);
            if (result)
            {
                await _channel.BasicAckAsync(eventArgs.DeliveryTag, false);
            }
        };
        await _channel.BasicConsumeAsync(Queue, false, consumer);

        // Aguardar até o cancellation token ser acionado
        await Task.Delay(Timeout.Infinite, stoppingToken);
    }

    private bool NotifyDonor(DonationCreated message)
    {
        if (message is not null)
        {
            Console.WriteLine("Thanks for donate!");

            return true;
        }
        return false;

    }

    private async Task InitializeRabbitMQAsync()
    {
        var connectionFactory = new ConnectionFactory
        {
            HostName = "localhost"
        };
        _connection = await connectionFactory.CreateConnectionAsync("donor-service-donation-created-consumer");
        _channel = await _connection.CreateChannelAsync();

        await _channel.ExchangeDeclareAsync(Exchange, "topic", true);
        await _channel.QueueDeclareAsync(Queue, false, false, false, null);
        await _channel.QueueBindAsync(Queue, Exchange, Queue);
        await _channel.QueueBindAsync(Queue, "donation-service", "donation-created");
    }

    public class DonationCreated
    {
        public string Id { get; set; }
        public string FullName { get; set; }
    }
}