using GuildSaber.Enums;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]

#if GUILDSABER_SERVER
[PrimaryKey(nameof(UserID))]
#endif
public class Player
{
#if GUILDSABER_SERVER
    [ForeignKey(nameof(User))]
#endif
    public uint UserID { get; set; }

#if GUILDSABER_SERVER
    [MaxLength(32)]
#endif
    public string Name { get;        set; } = string.Empty;
    public EPlatform Platform { get; set; }
    public EHMD      HMD      { get; set; } = EHMD.Unknown;
    public string    Country  { get; set; } = "Unknown";

#if GUILDSABER_SERVER
    public string? User_AvatarUrl { get => User?.AvatarUrl; }
#else
    public string? User_AvatarUrl { get; set; }
#endif

#if GUILDSABER_SERVER
    [JsonIgnore] public User? User { get; set; }

    [JsonIgnore] public ICollection<Score>?                   Scores                   { get; set; } = null;
    [JsonIgnore] public ICollection<RankedScore>?             RankedScores             { get; set; } = null;
    [JsonIgnore] public ICollection<Member>?                  MemberList               { get; set; } = null;
    [JsonIgnore] public ICollection<PlayerPointStat>?         PlayerPointStats         { get; set; } = null;
    [JsonIgnore] public ICollection<PlayerCategoryPointStat>? PlayerCategoryPointStats { get; set; } = null;
#endif
}
