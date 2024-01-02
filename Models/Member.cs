using GuildSaber.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(UserID), nameof(GuildID))]
public class Member
{
    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    [ForeignKey(nameof(User))]
    public uint UserID { get; set; }

    [JsonIgnore]
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
