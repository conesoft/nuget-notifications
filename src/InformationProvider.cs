using System;
using System.ComponentModel;

namespace Conesoft.Notifications;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class InformationProvider<DependencyInjected>(DependencyInjected injected, Func<DependencyInjected, Information> informationProvider) : IInformationProvider
{
    public Information GetInformation() => informationProvider(injected);
}