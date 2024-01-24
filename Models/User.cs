using GuildSaber.Enums;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class User
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

    public ulong? DiscordUserID { get; set; }
    public ulong? BeatLeaderID  { get; set; }

    public ESubscriptionTier        SubscriptionTier { get; set; } = ESubscriptionTier.Default;
    public ICollection<GuildBoost>? GuildBoosts      { get; set; } = null;


#if GUILDSABER_SERVER
    [JsonIgnore] public Player?                   Player       { get; set; } = null;
    [JsonIgnore] public string?                   AvatarUrl    { get; set; } = null;
    [JsonIgnore] public ICollection<UserSession>? UserSessions { get; set; }
#endif
}
