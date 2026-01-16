using System;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging;

public class MessageDispatcher : IMessageDispatcher
{
    private readonly IServiceProvider _serviceProvider;

    public MessageDispatcher(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }
         
    public async Task DispatchAsync<T>(T item) where T : BaseEvent, IAsyncEvent
    {
        using (var scope = _serviceProvider.CreateScope())
        {
            var handler = scope.ServiceProvider.GetRequiredService<IAsyncEventProcessor<T>>();
            await handler.Execute(item);
        }

        await Task.CompletedTask;
    }
}