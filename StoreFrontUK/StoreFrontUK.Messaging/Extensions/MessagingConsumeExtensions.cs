using System.Data;
using System.Linq.Expressions;
using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Messaging.Events;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging.Extensions;

public static class MessagingConsumeExtensions
{
    public async static Task Consume(this WebApplication app, params Type[] types)
    {
        var dispatcher = app.Services.GetRequiredService<IMessageDispatcher>() as MessageDispatcher;

        var rabbitType = typeof(RabbitMQService);
        var method = rabbitType.GetMethod("StartConsuming")!;

        foreach (var type in types)
        {
            //var eventType = ev.GetType();

            // Make generic method for the event type
            var genericMethod = method.MakeGenericMethod(type);

            // Create delegate: oce => oce.ExecuteAsync(dispatcher)
            //var paramType = typeof(Func<>).MakeGenericType(typeof(IAsyncEvent).MakeGenericType(eventType)); // adjust if needed
            var handlerDelegate = CreateHandlerDelegate(type, dispatcher!);

            // Invoke StartConsuming<T>(handlerDelegate)
            var task = (Task)genericMethod.Invoke(RabbitMQService.Instance, new object[] { handlerDelegate })!;
            await task;
        }
    }

    private static object CreateHandlerDelegate(Type eventType, MessageDispatcher dispatcher)
    {
        var asyncEventType = typeof(IAsyncEvent);
        var executeMethod = asyncEventType.GetMethod("ExecuteAsync", new[] { typeof(MessageDispatcher) })!;

        var param = Expression.Parameter(eventType, "e");
        var call = Expression.Call(param, executeMethod, Expression.Constant(dispatcher));
        var lambda = Expression.Lambda(call, param);

        return lambda.Compile();
    }
}