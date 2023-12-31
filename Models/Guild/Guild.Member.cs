﻿using Mbk.Discord.Enums;

using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Mbk.Discord.Models;

public partial class GuildMember
{
	//https://discord.com/developers/docs/resources/guild#guild-member-object

	/// <summary>
	/// The guild id wich the user joined
	/// </summary>
	[JsonPropertyName( "guild_id" )]
	public string GuildID { get; set; } = null;

	/// <summary>
	/// The user this guild member represents
	/// </summary>
	[JsonPropertyName( "user" )]
	public User User { get; set; } = null;

	/// <summary>
	/// this user's guild nickname
	/// </summary>
	[JsonPropertyName( "nick" )]
	public string NickName { get; set; } = null;

	/// <summary>
	/// The member's guild avatar hash
	/// </summary>
	[JsonPropertyName( "avatar" )]
	public string Avatar { get; set; } = null;

	/// <summary>
	/// The list of role object ids
	/// </summary>
	[JsonPropertyName( "roles" )]
	public IList<object> Roles { get; set; } = null;

	/// <summary>
	/// When the user joined the guild
	/// </summary>
	[JsonPropertyName( "joined_at" )]
	public string JoinedAt { get; set; } = null;

	/// <summary>
	/// When the user started boosting the guild
	/// </summary>
	[JsonPropertyName( "premium_since" )]
	public string PremiumSince { get; set; } = null;

	/// <summary>
	/// Whether the user is deafened in voice channels
	/// </summary>
	[JsonPropertyName( "deaf" )]
	public bool? Deaf { get; set; }

	/// <summary>
	/// Whether the user is muted in voice channels
	/// </summary>
	[JsonPropertyName( "mute" )]
	public bool? Mute { get; set; }

	/// <summary>
	/// Whether the user is muted in voice channels
	/// </summary>
	[JsonPropertyName( "flags" )]
	public GuildMemberFlags? Flags { get; set; }

	/// <summary>
	/// Whether the user has not yet passed the guild's Membership Screening requirements
	/// </summary>
	[JsonPropertyName( "pending" )]
	public bool? Pending { get; set; }

	/// <summary>
	/// Total permissions of the member in the channel, including overwrites, returned when in the interaction object
	/// </summary>
	[JsonPropertyName( "permissions" )]
	public string Permissions { get; set; } = null;

	/// <summary>
	/// When the user's timeout will expire and the user will be able to communicate in the guild again, null or a time in the past if the user is not timed out
	/// </summary>
	[JsonPropertyName( "communication_disabled_until" )]
	public object CommunicationDisabled { get; set; } = null;
}
