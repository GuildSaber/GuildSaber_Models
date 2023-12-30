using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public sealed class SongDifficulty
{
    public enum EDifficulty
    {
        Easy       = 1,
        Normal     = 3,
        Hard       = 5,
        Expert     = 7,
        ExpertPlus = 9
    }

    [Key]
    public uint ID { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(Song))]
    public uint SongID { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(GameMode))]
    public uint GameModeID { get;            set; }
    required public GameMode GameMode { get; set; }

    public EDifficulty Difficulty { get; set; }

    public Song? Song { get; set; } = null;

    /* Leaderboard ID */
    public string? BLID { get; set; } = null;

    /* Map stats (to avoid data duplicates) */
    [JsonIgnore]
    public uint SongDifficultyStatsID { get;               set; }
    public SongDifficultyStats? SongDifficultyStats { get; set; } = null;

    [JsonIgnore]
    public ICollection<RankedMapVersion>? RankedMapVersions { get; set; } = null;
}
