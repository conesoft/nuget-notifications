using FolkerKinzel.DataUrls;
using System.Text.Json;
using System.Threading.Tasks;
using IO = System.IO;

namespace Conesoft.Notifications;

public class Notifier(IInformationProvider information)
{
    static readonly JsonSerializerOptions options = new()
    {
        DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
    };

    public async Task Notify(string? title, string message, string? url = null, string? imagePath = null, string? to = null, string? from = null)
    {
        var notifications = IO.Path.Combine(information.GetInformation().Root, "plugins", "notifications");

        var newNotification = IO.Path.Combine(notifications, IO.Path.ChangeExtension(IO.Path.GetRandomFileName(), ".json"));

        var imageDataUrl = default(string);

        if (imagePath != null)
        {
            var dataUrl = DataUrl.FromFile(imagePath);
            if(DataUrl.TryParse(dataUrl, out var info))
            {
                if(info.MimeType.ToString().StartsWith("image/"))
                {
                    imageDataUrl = dataUrl;
                }
            }
        }

        await IO.File.WriteAllTextAsync(newNotification, JsonSerializer.Serialize(new
        {
            title,
            message,
            url,
            image = imageDataUrl,
            to,
            from = from ?? information.GetInformation().Name
        }, options));
    }
}