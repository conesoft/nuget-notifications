using Conesoft.Files;
using System.ComponentModel;

namespace Conesoft.Notifications;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IRootProvider
{
    public abstract Directory GetRoot();
}
