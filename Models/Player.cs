using GuildSaber.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(UserID))]
public class Player
{
    [ForeignKey(nameof(User))]
    public uint UserID { get; set; }

    [MaxLength(32)]
    public string Name { get;        set; } = string.Empty;
    public EPlatform Platform { get; set; }
    public EHMD      HMD      { get; set; } = EHMD.Unknown;

    public string? User_AvatarUrl { get => User?.AvatarUrl; }

    [JsonIgnore]
    public User? User { get; set; }

    [JsonIgnore]
    public ICollection<Score>? Scores { get; set; } = null;
    [JsonIgnore]
    public ICollection<RankedScore>? RankedScores { get; set; } = null;
    [JsonIgnore]
    public ICollection<Member>? MemberList { get; set; } = null;
    [JsonIgnore]
    public ICollection<PlayerPointStat>? PlayerPointStats { get; set; } = null;
    [JsonIgnore]
    public ICollection<PlayerCategoryPointStat>? PlayerCategoryPointStats { get; set; } = null;
}
