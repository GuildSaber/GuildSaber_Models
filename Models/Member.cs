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
    [Flags]
    public enum EJoinState : uint
    {
        None      = 0,
        Requested = 1 << 0,
        Joined    = 1 << 1,
        Refused   = 1 << 2,

        //Invited   = 1 << 3,
        Removed = 1 << 29,
        Banned  = 1 << 30,
        All     = Joined | Requested | Refused | Banned // | Invited
    }

    [Flags]
    public enum EPermission : uint
    {
        None              = 0,
        GuildLeader       = 1 << 0,
        RankingTeam       = 1 << 1,
        ScoringTeam       = 1 << 2,
        MemberTeam        = 1 << 3,
        GuildSaberManager = 1 << 30
    }

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
