using Conesoft.Files;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.ComponentModel;

namespace Conesoft.Notifications;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public static class AddNotificationServiceExtensions
{
    public static Builder AddNotificationService<DependencyInjected, Builder>(this Builder builder, Func<DependencyInjected, Directory> rootProvider) where Builder : IHostApplicationBuilder
    {
        builder.Services.AddTransient<IRootProvider, RootProvider<DependencyInjected>>((IServiceProvider services) => ActivatorUtilities.CreateInstance<RootProvider<DependencyInjected>>(services, rootProvider));
        builder.Services.AddTransient<NotificationService>();
        return builder;
    }
    public static HostApplicationBuilder AddNotificationService<DependencyInjected>(this HostApplicationBuilder builder, Func<DependencyInjected, Directory> rootProvider)
    {
        return builder.AddNotificationService<DependencyInjected, HostApplicationBuilder>(rootProvider);
    }
    public static WebApplicationBuilder AddNotificationService<DependencyInjected>(this WebApplicationBuilder builder, Func<DependencyInjected, Directory> rootProvider)
    {
        return builder.AddNotificationService<DependencyInjected, WebApplicationBuilder>(rootProvider);
    }
}
