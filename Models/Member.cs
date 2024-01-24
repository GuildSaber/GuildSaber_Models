using GuildSaber.Enums;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(UserID), nameof(GuildID))]
#endif
public class Member
{
#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(User))]
#endif
    public uint UserID { get; set; }

#if GUILDSABER_SERVER
    [JsonIgnore]
#endif
    public User? User { get;   set; } = null;
    public Guild? Guild { get; set; } = null;

    public EPermission Permissions { get; set; } = EPermission.None;
    public EJoinState  State       { get; set; } = EJoinState.None;

    public uint  Priority { get; set; } = 0;
    public ulong UnixTime { get; set; }

    public ESubscriptionTier SubscriptionTier
    {
        get => User?.GuildBoosts?.FirstOrDefault(p_X => p_X.GuildID == GuildID)?.Tier ?? ESubscriptionTier.Default;
    }
}
