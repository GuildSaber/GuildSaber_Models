using GuildSaber.Enums;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public sealed class SongDifficulty
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

#if GUILDSABER_SERVER
    [JsonIgnore]
    [ForeignKey(nameof(Song))]
    public uint SongID { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(GameMode))]
    public uint GameModeID { get; set; }
#endif

#if GUILDSABER_SERVER
    required public GameMode GameMode { get; set; }
#else
    public GameMode GameMode { get; set; } = null!;
#endif

    public EDifficulty Difficulty { get; set; }

    public string? BLID { get; set; } = null;
    public Song?   Song { get; set; } = null;

    /* Leaderboard ID */
    public SongDifficultyStats? SongDifficultyStats { get; set; } = null;

#if GUILDSABER_SERVER
    /* Map stats (to avoid data duplicates) */
    [JsonIgnore] public uint                           SongDifficultyStatsID { get; set; }
    [JsonIgnore] public ICollection<RankedMapVersion>? RankedMapVersions     { get; set; } = null;
#endif
}
