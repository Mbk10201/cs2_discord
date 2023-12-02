using CounterStrikeSharp.API.Core;
using System.Text.Json.Serialization;

namespace Mbk.Discord;

public class Configuration: BasePluginConfig
{
    [JsonPropertyName("IsPluginEnabled")]
    public bool IsPluginEnabled { get; set; } = true;

    [JsonPropertyName("Token")]
    public string? Token { get; set; }

    [JsonPropertyName("SteamAPI_Token")]
    public string? SteamAPIToken { get; set;}
}
