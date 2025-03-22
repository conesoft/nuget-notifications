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
    public static Builder AddNotificationService<DependencyInjected, Builder>(this Builder builder, Func<DependencyInjected, Information> informationProvider) where Builder : IHostApplicationBuilder
    {
        builder.Services.AddTransient<IInformationProvider, InformationProvider<DependencyInjected>>((IServiceProvider services) => ActivatorUtilities.CreateInstance<InformationProvider<DependencyInjected>>(services, informationProvider));
        builder.Services.AddTransient<Notifier>();
        return builder;
    }
    public static HostApplicationBuilder AddNotificationService<DependencyInjected>(this HostApplicationBuilder builder, Func<DependencyInjected, Information> informationProvider)
    {
        return builder.AddNotificationService<DependencyInjected, HostApplicationBuilder>(informationProvider);
    }
    public static WebApplicationBuilder AddNotificationService<DependencyInjected>(this WebApplicationBuilder builder, Func<DependencyInjected, Information> informationProvider)
    {
        return builder.AddNotificationService<DependencyInjected, WebApplicationBuilder>(informationProvider);
    }
}
