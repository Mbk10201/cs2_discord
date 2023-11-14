using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using Mbk.Discord.Models;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;

namespace Mbk.Discord;

public class Discord : BasePlugin, IPluginConfig<Configuration>
{
    public static Discord Instance { get; private set; }

    #region Plugin Information
    public override string ModuleName => "Discord";
    public override string ModuleVersion => "V1.0.0";
    public override string ModuleAuthor => "MbK";
    public override string ModuleDescription => "Log all your game events on your discord server.";
    #endregion

    #region Constants
    public const string Discord_ApiPoint = "https://discord.com/api";
    public const string APIVersion = "v10";
    public static string ConfigsPath => Path.Combine(Server.GameDirectory, "csgo", "addons", "counterstrikesharp", "configs", "plugins", "discord");
    #endregion

    #region Variables
    public List<GameEventSettings> GameEventList { get; set; } = new List<GameEventSettings>();
    #endregion

    #region Objects
    public Configuration Config { get; set; }
    public WebsocketClient? Websocket { get; private set; }
    public WebhookClient? Webhook { get; private set; }
    #endregion

    // This method is called right before `Load` is called
    public void OnConfigParsed(Configuration config)
    {
        // Save config instance
        Config = config;
    }

    public Discord()
    {
        Instance = this;
        DiscordGameEvent.Initialize();
    }

    #region Startup
    /* -----------------------------------------------------
     *    Ceci est la première fonction qui est appelé 
     *          lors de l'éxecution du plugin.
     * -----------------------------------------------------
     */
    public override void Load(bool hotReload)
    {
        // Basic usage of the configuration system
        if (!Config.IsPluginEnabled)
        {
            Console.WriteLine($"[Discord] The plugin is disabled");
            return;
        }

        Console.WriteLine("[Discord] The plugin started successfully.");
        Console.WriteLine($"[Discord] The plugin config path: {ConfigsPath}.");

        Websocket = new();
        Webhook = new();

        RegisterEventHandler<EventPlayerConnect>(OnPlayerConnect);
        RegisterEventHandler<EventPlayerDisconnect>(OnPlayerDisconnect);
        RegisterEventHandler<EventPlayerDeath>(OnPlayerDeathHandler);
        RegisterEventHandler<EventPlayerSpawn>(OnPlayerSpawnHandler);
        RegisterEventHandler<EventPlayerHurt>(OnPlayerHurtHandler);
    }
    #endregion

    [DiscordGameEvent("Client Connect", "client_connect", "When a client connect the server", options: {"", ""})]
    private HookResult OnPlayerConnect(EventPlayerConnect @event, GameEventInfo _)
    {
        var name = @event.Name;
        var userid = @event.Userid;

        var EventSettings = DiscordGameEvent.Get("client_connect");

        if (!EventSettings.Broadcast)
            return HookResult.Handled;

        var message = new MessageForm();

        if (EventSettings.DisplayEmbed)
        {
            message = new()
            {
                Embeds = new()
                {
                    new Embed()
                    {
                        Title = EventSettings.Name,
                        Description = $"`{name}` has joined the server.",
                        Color = EventSettings.GetColor()
                    }
                }
            };
        }
        else
        {
            message = new()
            {
                Content = $"{name} has joined the server"
            };
        }

        if (EventSettings.UseAsBot && Config.Token != "")
        {
            if (EventSettings.ChannelID is null)
                return HookResult.Handled;

            //Client.SendMessage(EventSettings.ChannelID.Value, message);
        }
        else
        {
            if (EventSettings.Webhook == string.Empty)
                return HookResult.Handled;

            WebhookClient.Send(EventSettings.Webhook, message);
        }

        return HookResult.Continue;
    }

    [DiscordGameEvent("Client Disconnect", "client_disconnect", "When a client leave the server")]
    private HookResult OnPlayerDisconnect(EventPlayerDisconnect @event, GameEventInfo _)
    {
        var name = @event.Name;
        var userid = @event.Userid;

        var EventSettings = DiscordGameEvent.Get("client_disconnect");

        if (!EventSettings.Broadcast)
            return HookResult.Handled;

        var message = new MessageForm();

        if (EventSettings.DisplayEmbed)
        {
            message = new()
            {
                Embeds = new()
                {
                    new Embed()
                    {
                        Title = EventSettings.Name,
                        Description = $"`{name}` has disconnected from server.",
                        Color = EventSettings.GetColor()
                    }
                }
            };
        }
        else
        {
            message = new()
            {
                Content = $"{name} has disconnected from server"
            };
        }

        if (EventSettings.UseAsBot && Config.Token != "")
        {
            if (EventSettings.ChannelID is null)
                return HookResult.Handled;

            //Client.SendMessage(EventSettings.ChannelID.Value, message);
        }
        else
        {
            if (EventSettings.Webhook == string.Empty)
                return HookResult.Handled;

            WebhookClient.Send(EventSettings.Webhook, message);
        }

        return HookResult.Continue;
    }

    private HookResult OnPlayerHurtHandler(EventPlayerHurt @event, GameEventInfo _)
    {
        var victim = @event.Userid;
        var attacker = @event.Attacker;

        return HookResult.Continue;
    }

    private HookResult OnPlayerSpawnHandler(EventPlayerSpawn @event, GameEventInfo _)
    {
        var player = @event.Userid;

        return HookResult.Continue;
    }

    [DiscordGameEvent("Player Death", "player_death", "When a client has been killed")]
    private HookResult OnPlayerDeathHandler(EventPlayerDeath @event, GameEventInfo _)
    {
        var attacker = @event.Attacker;
        var victim = @event.Userid;
        var headshot = @event.Headshot;

        var EventSettings = DiscordGameEvent.Get("client_disconnect");

        if (!EventSettings.Broadcast)
            return HookResult.Handled;

        var message = new MessageForm();

        if (EventSettings.DisplayEmbed)
        {
            message = new()
            {
                Embeds = new()
                {
                    new Embed()
                    {
                        Title = EventSettings.Name,
                        Description = $"`{victim.PlayerName}` has been killed by {attacker.PlayerName}.",
                        Color = EventSettings.GetColor()
                    }
                }
            };
        }
        else
        {
            message = new()
            {
                Content = $"`{victim.PlayerName}` has been killed by {attacker.PlayerName}."
            };
        }

        if (EventSettings.UseAsBot && Config.Token != "")
        {
            if (EventSettings.ChannelID is null)
                return HookResult.Handled;

            //Client.SendMessage(EventSettings.ChannelID.Value, message);
        }
        else
        {
            if (EventSettings.Webhook == string.Empty)
                return HookResult.Handled;

            WebhookClient.Send(EventSettings.Webhook, message);
        }

        return HookResult.Continue;
    }
}
