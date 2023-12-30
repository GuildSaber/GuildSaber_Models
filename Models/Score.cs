using GuildSaber.Enums;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class Score
{
    [Key]
    public uint ID { get; set; }

    [ForeignKey(nameof(Models.Player))]
    public uint PlayerID { get; set; }

    [ForeignKey(nameof(SongDifficulty))]
    public uint SongDifficultyID { get; set; }

    public uint       BaseScore   { get; set; }
    public EModifiers Modifiers   { get; set; }
    public uint       UnixTimeSet { get; set; }

    public uint? BL_ScoreID  { get; set; } /* Set as nullable for now to allow non-bl stats to be added */
    public uint  MaxCombo    { get; set; }
    public bool  FullCombo   { get; set; }
    public uint  MissedNotes { get; set; }
    public uint  BadCuts     { get; set; }

    public EHMD        HMD        { get; set; }
    public EController Controller { get; set; }

    public bool HasTrackers { get; set; }

    /* Trackers */
    public HitTracker?        HitTracker      { get; set; } = null;
    public WinTracker?        WinTracker      { get; set; } = null;
    public AccuracyTracker?   AccuracyTracker { get; set; } = null;
    public ScoreGraphTracker? GraphTracker    { get; set; } = null;

    [JsonIgnore]
    public Player? Player { get; set; } = null;
    [JsonIgnore]
    public SongDifficulty? SongDifficulty { get; set; } = null;

    [JsonIgnore]
    [InverseProperty(nameof(RankedScore.Score))]
    public ICollection<RankedScore> RankedScores { get; set; } = new List<RankedScore>(0);

    [JsonIgnore]
    [InverseProperty(nameof(RankedScore.PrevScore))]
    public ICollection<RankedScore> PrevRankedScores { get; set; } = new List<RankedScore>(0);
}
