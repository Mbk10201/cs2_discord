﻿using System.Text.Json.Serialization;

namespace Mbk.Discord.Models;

public partial class Guild
{
	// // According to the discord docs (https://discord.com/developers/docs/resources/guild#guild-object)

	/// <summary>
	/// Guild id
	/// </summary>
	[JsonPropertyName( "id" )]
	public string Id { get; set; }

	/// <summary>
	///	Guild name (2-100 characters, excluding trailing and leading whitespace)
	/// </summary>
	[JsonPropertyName( "name" )]
	public string Name { get; set; } = null;

	/// <summary>
	/// Icon hash
	/// https://discord.com/developers/docs/reference#image-formatting
	/// </summary>
	[JsonPropertyName( "icon" )]
	public string Icon { get; set; } = null;

	/// <summary>
	/// Icon hash, returned when in the template object
	/// https://discord.com/developers/docs/reference#image-formatting
	/// </summary>
	[JsonPropertyName( "icon_hash" )]
	public string IconHash { get; set; } = null;

	/// <summary>
	/// Splash hash
	/// https://discord.com/developers/docs/reference#image-formatting
	/// </summary>
	[JsonPropertyName( "splash" )]
	public string Splash { get; set; } = null;

	/// <summary>
	/// Discovery splash hash; only present for guilds with the "DISCOVERABLE" feature
	/// https://discord.com/developers/docs/reference#image-formatting
	/// </summary>
	[JsonPropertyName( "discovery_splash" )]
	public string DiscoverySplash { get; set; } = null;

	/// <summary>
	/// True if the user is the owner of the guild
	/// https://discord.com/developers/docs/resources/user#get-current-user-guilds
	/// </summary>
	[JsonPropertyName( "owner" )]
	public bool? Owner { get; set; }

	/// <summary>
	/// Id of owner
	/// </summary>
	[JsonPropertyName( "owner_id" )]
	public string OwnerID { get; set; } = null;

	/// <summary>
	/// Total permissions for the user in the guild (excludes overwrites)
	/// https://discord.com/developers/docs/resources/user#get-current-user-guilds
	/// </summary>
	[JsonPropertyName( "permissions" )]
	public ulong Permissions { get; set; }

	/// <summary>
	/// Voice region id for the guild (deprecated)
	/// https://discord.com/developers/docs/resources/voice#voice-region-object
	/// </summary>
	[JsonPropertyName( "region" )]
	public string Region { get; set; } = null;

	/// <summary>
	/// Id of afk channel
	/// </summary>
	[JsonPropertyName( "afk_channel_id" )]
	public string AFKChannelID { get; set; } = null;

	/// <summary>
	/// Afk timeout in seconds
	/// </summary>
	[JsonPropertyName( "afk_timeout" )]
	public int? AFKTimeout { get; set; }

	/// <summary>
	/// True if the server widget is enabled
	/// </summary>
	[JsonPropertyName( "widget_enabled" )]
	public bool? WidgetEnabled { get; set; }

	/// <summary>
	/// The channel id that the widget will generate an invite to, or null if set to no invite
	/// </summary>
	[JsonPropertyName( "widget_channel_id" )]
	public string WidgetChannelID { get; set; } = null;

	/// <summary>
	/// Verification level required for the guild
	/// https://discord.com/developers/docs/resources/guild#guild-object-verification-level
	/// </summary>
	[JsonPropertyName( "verification_level" )]
	public int? VerificationLevel { get; set; }

	/// <summary>
	/// Default message notifications level
	/// https://discord.com/developers/docs/resources/guild#guild-object-default-message-notification-level
	/// </summary>
	[JsonPropertyName( "default_message_notifications" )]
	public int? DefaultMessageNotifications { get; set; }

	/// <summary>
	/// Explicit content filter level
	/// https://discord.com/developers/docs/resources/guild#guild-object-explicit-content-filter-level
	/// </summary>
	[JsonPropertyName( "explicit_content_filter" )]
	public int? ExplicitContentFilter { get; set; }

	/// <summary>
	/// Roles in the guild
	/// </summary>
	[JsonPropertyName( "roles" )]
	public IList<Role> Roles { get; set; } = new List<Role>();

	/// <summary>
	/// Custom guild emojis
	/// </summary>
	[JsonPropertyName( "emojis" )]
	public IList<Emoji> Emojis { get; set; } = new List<Emoji>();

	/// <summary>
	/// Enabled guild features
	/// </summary>
	[JsonPropertyName( "features" )]
	public IList<string> Features { get; set; } = new List<string>();

	/// <summary>
	/// Required MFA level for the guild
	/// </summary>
	[JsonPropertyName( "mfa_level" )]
	public int? MFALevel { get; set; }

	/// <summary>
	/// Application id of the guild creator if it is bot-created
	/// </summary>
	[JsonPropertyName( "application_id" )]
	public string ApplicationID { get; set; } = null;

	/// <summary>
	/// The id of the channel where guild notices such as welcome messages and boost events are posted
	/// </summary>
	[JsonPropertyName( "system_channel_id" )]
	public string SystemChannelID { get; set; } = null;

	/// <summary>
	/// System channel flags
	/// </summary>
	[JsonPropertyName( "system_channel_flags" )]
	public int? SystemChannelFlags { get; set; }

	/// <summary>
	/// The id of the channel where Community guilds can display rules and/or guidelines
	/// </summary>
	[JsonPropertyName( "rules_channel_id" )]
	public string RulesChannelID { get; set; } = null;

	/// <summary>
	/// The maximum number of presences for the guild (null is always returned, apart from the largest of guilds)
	/// </summary>
	[JsonPropertyName( "max_presences" )]
	public int? MaxPresence { get; set; }

	/// <summary>
	/// The maximum number of members for the guild
	/// </summary>
	[JsonPropertyName( "max_members" )]
	public int? MaxMembers { get; set; }

	/// <summary>
	/// The vanity url code for the guild
	/// </summary>
	[JsonPropertyName( "vanity_url_code" )]
	public string VanityUrlCode { get; set; } = null;

	/// <summary>
	/// The description of a guild
	/// </summary>
	[JsonPropertyName( "description" )]
	public string Description { get; set; } = null;

	/// <summary>
	/// Banner hash
	/// https://discord.com/developers/docs/reference#image-formatting
	/// </summary>
	[JsonPropertyName( "banner" )]
	public string Banner { get; set; } = null;

	/// <summary>
	/// Premium tier (Server Boost level)
	/// https://discord.com/developers/docs/resources/guild#guild-object-premium-tier
	/// </summary>
	[JsonPropertyName( "premium_tier" )]
	public int? PremiumTier { get; set; }

	/// <summary>
	/// The number of boosts this guild currently has
	/// </summary>
	[JsonPropertyName( "premium_subscription_count" )]
	public int? PremiumSubscriptionCount { get; set; }

	/// <summary>
	///	The preferred locale of a Community guild; used in server discovery and notices from Discord, and sent in interactions; defaults to "en-US"
	/// https://discord.com/developers/docs/reference#locales
	/// </summary>
	[JsonPropertyName( "preferred_locale" )]
	public string PreferredLocale { get; set; } = null;

	/// <summary>
	///	The id of the channel where admins and moderators of Community guilds receive notices from Discord
	/// </summary>
	[JsonPropertyName( "public_updates_channel_id" )]
	public string PublicUpdatesChannelId { get; set; } = null;

	/// <summary>
	///	The maximum amount of users in a video channel
	/// </summary>
	[JsonPropertyName( "max_video_channel_users" )]
	public int? MaxVideoChannelUsers { get; set; }

	/// <summary>
	///	The maximum amount of users in a stage video channel
	/// </summary>
	[JsonPropertyName( "max_stage_video_channel_users" )]
	public int? MaxStageVideoChannelUsers { get; set; }

	/// <summary>
	///	Approximate number of members in this guild, returned from the GET /guilds/id endpoint when with_counts is true
	/// </summary>
	[JsonPropertyName( "approximate_member_count" )]
	public int? ApproximateMemberCount { get; set; }

	/// <summary>
	///	Approximate number of non-offline members in this guild, returned from the GET /guilds/id endpoint when with_counts is true
	/// </summary>
	[JsonPropertyName( "approximate_presence_count" )]
	public int? ApproximatePresenceCount { get; set; }

	/// <summary>
	/// The welcome screen of a Community guild, shown to new members, returned in an Invite's guild object
	/// </summary>
	[JsonPropertyName( "welcome_screen" )]
	public WelcomeScreen WelcomeScreen { get; set; } = null;

	/// <summary>
	/// Guild NSFW level
	/// https://discord.com/developers/docs/resources/guild#guild-object-guild-nsfw-level
	/// </summary>
	[JsonPropertyName( "nsfw_level" )]
	public int? NsfwLevel { get; set; }

	/// <summary>
	/// Custom guild stickers
	/// </summary>
	[JsonPropertyName( "stickers" )]
	public IList<Sticker> Stickers { get; set; } = new List<Sticker>();

	/// <summary>
	/// Whether the guild has the boost progress bar enabled
	/// </summary>
	[JsonPropertyName( "premium_progress_bar_enabled" )]
	public bool? PremiumProgressBarEnabled { get; set; }

	/// <summary>
	/// The id of the channel where admins and moderators of Community guilds receive safety alerts from Discord
	/// </summary>
	[JsonPropertyName( "safety_alerts_channel_id" )]
	public string SafetyAlertsChannelID { get; set; } = null;

	/// <summary>
	/// When this guild was joined at
	/// </summary>
	[JsonPropertyName( "joined_at" )]
	public string JoinedAt { get; set; }

	/// <summary>
	/// true if this is considered a large guild
	/// </summary>
	[JsonPropertyName( "large" )]
	public bool Large { get; set; }

	/// <summary>
	///	True if this guild is unavailable due to an outage
	/// </summary>
	[JsonPropertyName( "unavailable" )]
	public bool Unavailable { get; set; }

	/// <summary>
	///	Total number of members in this guild
	/// </summary>
	[JsonPropertyName( "member_count" )]
	public int MemberCount { get; set; }

	/// <summary>
	///	States of members currently in voice channels; lacks the guild_id key
	/// </summary>
	[JsonPropertyName( "voice_states" )]
	public IList<VoiceState> VoiceStates { get; set; } = new List<VoiceState>();

	/// <summary>
	///	Users in the guild
	/// </summary>
	[JsonPropertyName( "members" )]
	public IList<GuildMember> Members { get; set; } = new List<GuildMember>();

	/// <summary>
	///	Channels in the guild
	/// </summary>
	[JsonPropertyName( "channels" )]
	public IList<Channel> Channels { get; set; }

	/// <summary>
	///	All active threads in the guild that current user has permission to view
	/// </summary>
	[JsonPropertyName( "threads " )]
	public IList<Channel> Threads { get; set; } = new List<Channel>();

	/// <summary>
	///		Presences of the members in the guild, will only include non-offline members if the size is greater than large threshold
	/// </summary>
	[JsonPropertyName( "presences" )]
	public IList<Presence> Presences { get; set; } = new List<Presence>();

	/// <summary>
	///	Stage instances in the guild
	/// </summary>
	[JsonPropertyName( "stage_instances" )]
	public IList<Stage> StageInstances { get; set; } = new List<Stage>();

	/// <summary>
	/// Scheduled events in the guild
	/// </summary>
	[JsonPropertyName( "guild_scheduled_events" )]
	public IList<GuildScheduledEvent> GuildScheduledEvents { get; set; } = new List<GuildScheduledEvent>();
}
