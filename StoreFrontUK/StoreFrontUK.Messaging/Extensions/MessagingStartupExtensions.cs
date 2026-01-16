using Microsoft.Extensions.DependencyInjection;
using StoreFrontUK.Messaging.Interfaces;

namespace StoreFrontUK.Messaging.Extensions;

public static class MessagingStartupExtensions
{
    public static IServiceCollection AddMessaging(this IServiceCollection services)
    {
        services.AddSingleton<IMessageDispatcher, MessageDispatcher>();
        return services;
    }
}
