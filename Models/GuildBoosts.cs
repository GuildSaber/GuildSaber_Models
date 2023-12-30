using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[Flags]
public enum ESubscriptionTier
{
    Default = 0,
    Tier1   = 1 << 0,
    Tier2   = 1 << 1,
    Tier3   = 1 << 2
}

/// <summary>
///     The patreon boosts are defined so the users can give boosts to the guilds they choose.
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(UserID), nameof(GuildID))]
public class GuildBoosts
{
    [JsonIgnore]
    [ForeignKey(nameof(User))]
    public uint UserID { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    public ESubscriptionTier Tier { get; set; } = ESubscriptionTier.Default;

    /// <summary>
    ///     Expire time in case someone cancels their subscription. (Also allows for a grace period and to generate Boosts that
    ///     can cancel after some time on the fly if needed)
    /// </summary>
    public ulong UnixExpireTime { get; set; } = 0;

    public ulong UnixRemainingBoostTime { get => UnixExpireTime - (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); }
    public bool  IsExpired              { get => UnixExpireTime <= (ulong)DateTimeOffset.UtcNow.ToUnixTimeSeconds(); }
}
