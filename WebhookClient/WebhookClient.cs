using Mbk.Discord.Models;
using System.Text.Json;

namespace Mbk.Discord;

public class WebhookClient
{
    #region Instances
    public static WebhookClient? Instance { get; private set; }
    #endregion

    #region Objects
    private static readonly HttpClient client = new();
    public static IList<MessageForm> Logs { get; private set; } = new List<MessageForm>();
    #endregion

    public WebhookClient()
    {
        Instance = this;

        var url = "https://discord.com/api/webhooks/1173909332874772500/IZ1FigblEKfa4BSDJ3MPu7VX5ZK4_6sNR_P15pBdkegw4z5QxrM4HMrwsq516ghEgUdL";
        _ = Send(url, 
            new MessageForm()
            {
                Embeds = new()
                {
                    new()
                    {
                        Title = "Startup",
                        Description = $"Startup of server",
                        Color = 16662785,
                        Fields = new()
                        {
                            new ()
                            {
                                Name = "IP",
                                Value = "127.0.0.1:27015"
                            }
                        }
                    }
                }
            });
    }

    public static async Task Send(string url, MessageForm message)
    {

        Logs.Add(message);

        var httpContent = new StringContent(JsonSerializer.Serialize(message), System.Text.Encoding.UTF8, "application/json");
        var response = await client.PostAsync(url, httpContent);
        var result = await response.Content.ReadAsStringAsync();

        Console.Write(result);
    }
}
