using Conesoft.Files;
using FolkerKinzel.DataUrls;
using System.Text.Json;
using System.Threading.Tasks;
using IO = System.IO;

namespace Conesoft.Notifications;

public class Notifier(IRootProvider access)
{
    static readonly JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public async Task Notify(string? title, string message, string? url = null, File? image = null)
    {
        var notifications = access.GetRoot() / "plugins" / "notifications";

        var newNotification = notifications / Filename.From(IO.Path.GetRandomFileName(), ".json");

        var imageDataUrl = default(string);

        if (image != null)
        {
            var dataUrl = DataUrl.FromFile(image.Path);
            if(DataUrl.TryParse(dataUrl, out var info))
            {
                if(info.MimeType.ToString().StartsWith("image/"))
                {
                    imageDataUrl = dataUrl;
                }
            }
        }

        await newNotification.WriteAsJson(new
        {
            title,
            message,
            url,
            image = imageDataUrl
        }, options);
    }
}