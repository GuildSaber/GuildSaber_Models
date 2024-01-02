using GuildSaber.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class User
{
    [Key]
    public uint ID { get; set; }

    [JsonIgnore]
    public Player? Player { get; set; } = null;

    public ulong? DiscordUserID { get; set; }
    public ulong? BeatLeaderID  { get; set; }

    [JsonIgnore]
    public string? AvatarUrl { get; set; } = null;

    [JsonIgnore]
    public ICollection<UserSession>? UserSessions { get; set; }

    public ESubscriptionTier         SubscriptionTier { get; set; } = ESubscriptionTier.Default;
    public ICollection<GuildBoosts>? GuildBoosts      { get; set; } = null;
}
