using System.Text;
using System.Text.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging;

public sealed class RabbitMQService : IDisposable
{
    private static readonly Lazy<RabbitMQService> _instance = new(() => new RabbitMQService());

    public static RabbitMQService Instance => _instance.Value;

    private static bool Initialized = false;

    private IConnection? _connection;
    private IChannel? _channel;

    private bool _forceConfirmation;

    public async Task InitializeAsync(string hostName, bool forceConfirmation = false)
    {
        try
        {
            if (!Initialized)
            {
                var factory = new ConnectionFactory { HostName = hostName };
                _connection = await factory.CreateConnectionAsync();
                _forceConfirmation = forceConfirmation;
                var channelOpts = new CreateChannelOptions(publisherConfirmationsEnabled: _forceConfirmation,
                                                            publisherConfirmationTrackingEnabled: _forceConfirmation);
                _channel = await _connection.CreateChannelAsync(channelOpts);
                await _channel.ExchangeDeclareAsync("dlx", ExchangeType.Direct, true);
                await _channel.ExchangeDeclareAsync("stock.request.exchange", ExchangeType.Fanout, true);
                Initialized = true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error {ex.Message}");
        }
        
    }

    public async Task PublishAsync<T>(T message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        var props = new BasicProperties
        {
            DeliveryMode = DeliveryModes.Persistent,
            Persistent = true
        };

        var queueName = typeof(T).Name;
        
        try
        {
            await _channel!.BasicPublishAsync(exchange: "", routingKey: queueName, mandatory: true, basicProperties: props, body);
        }
        catch (AlreadyClosedException ex)
        {
            Console.WriteLine($"Publish: {queueName} - {ex.Message}");
        }
    }

    public async Task PublishToExchange<T>(T message)
    {
        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(message));
        var props = new BasicProperties
        {
            DeliveryMode = DeliveryModes.Persistent,
            Persistent = true
        };

        try
        {
            await _channel!.BasicPublishAsync(exchange: "stock.request.exchange", routingKey: "", mandatory: true, basicProperties: props, body);
        }
        catch (AlreadyClosedException ex)
        {
            Console.WriteLine($"PublishToExchange: stock.request.exchange - {ex.Message}");
        }
    }

    public async Task StartConsumingSupplier<T>(Func<T, Task> onMessageReceived) where T : BaseEvent, IAsyncEvent
    {
        var queueName = typeof(T).Name;
        
        await _channel!.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        await _channel!.QueueBindAsync(queue: queueName, exchange: "stock.request.exchange", routingKey: "");
        await Consume(onMessageReceived, queueName);
        await Task.CompletedTask;
    }

    public async Task StartConsuming<T>(Func<T, Task> onMessageReceived) where T : BaseEvent, IAsyncEvent
    {
        try
        {
            var queueName = typeof(T).Name;

            await CreateQueues(queueName);
            await Consume(onMessageReceived, queueName);
            await Task.CompletedTask;
        }
        catch(Exception ex)
        {
            Console.WriteLine($"StartConsuming ... {ex.Message} .... ");
        }
        
    }

    public async Task AcceptMessage(ulong deliveryTag) => await _channel!.BasicAckAsync(deliveryTag, false);

    public async Task RejectMessage(ulong deliveryTag) => await _channel!.BasicRejectAsync(deliveryTag, false);
    
    public void Dispose()
    {
        _channel?.Dispose();
        _connection?.Dispose();
    }

    private async Task Consume<T>(Func<T, Task> onMessageReceived, string queueName) where T : BaseEvent, IAsyncEvent
    {
        try
        {
            var consumer = new AsyncEventingBasicConsumer(_channel!);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var json = Encoding.UTF8.GetString(body);
                var message = JsonSerializer.Deserialize<T>(json);
                message!.DeliveryTag = ea.DeliveryTag;
                await onMessageReceived(message!);
            };

            await _channel!.BasicConsumeAsync(queueName, autoAck: false, consumer: consumer);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Consume - {ex.Message}");
        }
    }

    private async Task CreateQueues(string queueName)
    {
        try
        {
            var args = new Dictionary<string, object?>
            {
                { "x-dead-letter-exchange", "dlx" },
                { "x-dead-letter-routing-key", $"{queueName}-dlq" }
            };

            await _channel!.QueueDeclareAsync(queue: $"{queueName}-dlq", durable: true, exclusive: false, autoDelete: false);
            await _channel!.QueueBindAsync(queue: $"{queueName}-dlq", exchange: "dlx", routingKey: $"{queueName}-dlq");
            await _channel!.QueueDeclareAsync(queue: queueName, durable: true, exclusive: false, autoDelete: false, arguments: args);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Create Queues - {ex.Message}");
        }
    }
}