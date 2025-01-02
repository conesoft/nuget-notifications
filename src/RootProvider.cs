using Conesoft.Files;
using System;
using System.ComponentModel;

namespace Conesoft.Notifications;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public class RootProvider<DependencyInjected>(DependencyInjected injected, Func<DependencyInjected, Directory> method) : IRootProvider
{
    public Directory GetRoot() => method(injected);
}