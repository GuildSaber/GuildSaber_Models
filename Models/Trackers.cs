using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

/*/// <summary>
///     BeatLeader Score Statistic model
/// </summary>
[Owned]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class Trackers
{
    public HitTracker?        HitTracker      { get; set; } = null;
    public WinTracker?        WinTracker      { get; set; } = null;
    public AccuracyTracker?   AccuracyTracker { get; set; } = null;
    public ScoreGraphTracker? GraphTracker    { get; set; } = null;
}*/

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class HitTracker
{
    [Required]
    [Key]
    [ForeignKey(nameof(Score))]
    public uint ScoreID { get; set; }

    public int   MaxCombo     { get; set; }
    public int?  MaxStreak    { get; set; }
    public float LeftTiming   { get; set; }
    public float RightTiming  { get; set; }
    public int   LeftMiss     { get; set; }
    public int   RightMiss    { get; set; }
    public int   LeftBadCuts  { get; set; }
    public int   RightBadCuts { get; set; }
    public int   LeftBombs    { get; set; }
    public int   RightBombs   { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class WinTracker
{
    [Required]
    [Key]
    [ForeignKey(nameof(Score))]
    public uint ScoreID { get; set; }

    public bool             Won                 { get; set; }
    public float            EndTime             { get; set; }
    public int              PauseCount          { get; set; }
    public float            TotalPauseDuration  { get; set; }
    public float            JumpDistance        { get; set; }
    public float            AverageHeight       { get; set; }
    public AveragePosition? AverageHeadPosition { get; set; }
    public int              TotalScore          { get; set; }
    public int              MaxScore            { get; set; }
}

[Owned]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class AveragePosition
{
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class AccuracyTracker
{
    [Required]
    [Key]
    [ForeignKey(nameof(Score))]
    public uint ScoreID { get; set; }

    public float  AccRight            { get; set; }
    public float  AccLeft             { get; set; }
    public float  LeftPreSwing        { get; set; }
    public float  RightPreSwing       { get; set; }
    public float  AveragePreSwing     { get; set; }
    public float  LeftPostSwing       { get; set; }
    public float  RightPostSwing      { get; set; }
    public float  LeftTimeDependence  { get; set; }
    public float  RightTimeDependence { get; set; }
    public string LeftAverageCut      { get; set; } = string.Empty; /* format List<float> */
    public string RightAverageCut     { get; set; } = string.Empty; /* format List<float> */
    public string GridAcc             { get; set; } = string.Empty; /* format List<float> */
    public float  FC_Acc              { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class ScoreGraphTracker
{
    [Required]
    [Key]
    [ForeignKey(nameof(Score))]
    public uint ScoreID { get; set; }

    public string Graph { get; set; } = string.Empty; /* format List<float> */
}
