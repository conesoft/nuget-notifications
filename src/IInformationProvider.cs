using System.ComponentModel;

namespace Conesoft.Notifications;

[Browsable(false)]
[EditorBrowsable(EditorBrowsableState.Never)]
public interface IInformationProvider
{
    public abstract Information GetInformation();
}
