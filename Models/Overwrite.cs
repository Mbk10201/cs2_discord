using System.Text.Json.Serialization;

namespace Mbk.Discord.Models;

public partial class Overwrite
{
	// https://discord.com/developers/docs/resources/channel#overwrite-object

	/// <summary>
	///	Role or user id
	/// </summary>
	[JsonPropertyName( "id" )]
	public string Id { get; set; }

	/// <summary>
	/// Either 0 (role) or 1 (member)
	/// </summary>
	[JsonPropertyName( "type" )]
	public string Type { get; set; }

	/// <summary>
	/// Permission bit set
	/// </summary>
	[JsonPropertyName( "roles" )]
	public string Allow { get; set; }

	/// <summary>
	/// Permission bit set
	/// </summary>
	[JsonPropertyName( "deny" )]
	public ulong Deny { get; set; }
}
