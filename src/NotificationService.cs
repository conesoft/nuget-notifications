using Conesoft.Files;
using System.Threading.Tasks;
using IO = System.IO;

namespace Conesoft.Notifications;

public class NotificationService(IRootProvider access)
{
    public async Task Notify(string? title, string message, string url)
    {
        var notifications = access.GetRoot() / "plugins" / "notifications";

        var newNotification = notifications / Filename.From(IO.Path.GetRandomFileName(), ".json");

        await newNotification.WriteAsJson(new
        {
            title,
            message,
            url
        });
    }
}