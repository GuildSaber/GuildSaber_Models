using GuildSaber.Enums;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Newtonsoft.Json;
#endif

#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
#endif

namespace GuildSaber.Models;

/// <summary>
///     Contains all the guild's scores
/// </summary>
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class RankedScore : IComparable<RankedScore>
{
    ///////////////////////// SQL FormattableStrings ///////////////////////////
    ////////////////////////////////////////////////////////////////////////////

#if GUILDSABER_SERVER
    // ReSharper disable once UseRawString
    public const string UPDATE_RANK_FORMATTABLE_STRING = @"
                UPDATE RankedScores AS rs
                JOIN (
                    SELECT ID, DENSE_RANK() OVER (
                        PARTITION BY RankedMapID, PointID
                        ORDER BY IF(State = 1, 1, 2), RawPoints DESC, EffectiveScore DESC
                    ) AS NewRank
                    FROM RankedScores
                    WHERE RankedMapID = {0}
                ) AS subquery
                ON rs.ID = subquery.ID
                SET rs.Rank = subquery.NewRank
                WHERE rs.RankedMapID = {0}";
#endif

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Point))]
#endif
    public uint PointID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Player))]
#endif
    public uint PlayerID { get; set; }

    public Score?          Score          { get; set; }
    public Score?          PrevScore      { get; set; } = null;
    public RankedMap?      RankedMap      { get; set; }
    public Point?          Point          { get; set; } = null;
    public SongDifficulty? SongDifficulty { get; set; }
    public EPassState      State          { get; set; }

    public uint  EffectiveScore   { get; set; }
    public float RawPoints        { get; set; }
    public uint  CreatedUnixTime  { get; set; }
    public uint  ModifiedUnixTime { get; set; }

#if GUILDSABER_SERVER
    [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
#endif
    public uint Rank { get; set; }

    /* Calculated Field (Use RankedScoreWithWeight to set it's value) */
#if GUILDSABER_SERVER
    [NotMapped]
#endif
    public float Weight { get; set; } = 1;
#if GUILDSABER_SERVER
    [NotMapped]
#endif
    public uint RowNumber { get; set; }

    /* Implemented for the IComparable interface, to sort the scores too */
    public int CompareTo(RankedScore? other)
    {
        if (other is null) return 1;

        var l_RawPointsComparison = RawPoints.CompareTo(other.RawPoints);
        if (State == other.State) return l_RawPointsComparison == 0 ? EffectiveScore.CompareTo(other.EffectiveScore) : l_RawPointsComparison;
        if (State == EPassState.Allowed) return -1;

        return other.State == EPassState.Allowed ? 1 : l_RawPointsComparison == 0 ? EffectiveScore.CompareTo(other.EffectiveScore) : l_RawPointsComparison;
    }

    /* Operator overwrites are used for the sorting, to tell which scores are simply better than others in most situation */
    /////////////////////////// Operator overwrites ////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public static bool operator <(RankedScore p_Left, RankedScore p_Right)
    {
        var l_RawPointsComparison = p_Left.RawPoints.CompareTo(p_Right.RawPoints);
        if (p_Left.State  == p_Right.State) return l_RawPointsComparison == 0 ? p_Left.EffectiveScore < p_Right.EffectiveScore : l_RawPointsComparison < 0;
        if (p_Left.State  == EPassState.Allowed) return false;
        if (p_Right.State == EPassState.Allowed) return true;

        return l_RawPointsComparison < 0 || p_Left.EffectiveScore < p_Right.EffectiveScore;
    }

    public static bool operator >(RankedScore p_Left, RankedScore p_Right)
    {
        var l_RawPointsComparison = p_Left.RawPoints.CompareTo(p_Right.RawPoints);
        if (p_Left.State  == p_Right.State) return l_RawPointsComparison == 0 ? p_Left.EffectiveScore > p_Right.EffectiveScore : l_RawPointsComparison > 0;
        if (p_Left.State  == EPassState.Allowed) return true;
        if (p_Right.State == EPassState.Allowed) return false;

        return l_RawPointsComparison > 0 || p_Left.EffectiveScore > p_Right.EffectiveScore;
    }

    public static bool operator <=(RankedScore p_Left, RankedScore p_Right)
    {
        var l_RawPointsComparison = p_Left.RawPoints.CompareTo(p_Right.RawPoints);
        if (p_Left.State  == p_Right.State) return l_RawPointsComparison == 0 ? p_Left.EffectiveScore <= p_Right.EffectiveScore : l_RawPointsComparison <= 0;
        if (p_Left.State  == EPassState.Allowed) return false;
        if (p_Right.State == EPassState.Allowed) return true;

        return l_RawPointsComparison < 0 || p_Left.EffectiveScore <= p_Right.EffectiveScore;
    }

    public static bool operator >=(RankedScore p_Left, RankedScore p_Right)
    {
        var l_RawPointsComparison = p_Left.RawPoints.CompareTo(p_Right.RawPoints);
        if (p_Left.State  == p_Right.State) return p_Left.RawPoints.CompareTo(p_Right.RawPoints) == 0 ? p_Left.EffectiveScore >= p_Right.EffectiveScore : l_RawPointsComparison >= 0;
        if (p_Left.State  == EPassState.Allowed) return true;
        if (p_Right.State == EPassState.Allowed) return false;

        return l_RawPointsComparison > 0 || p_Left.EffectiveScore >= p_Right.EffectiveScore;
    }

#if GUILDSABER_SERVER
    [JsonIgnore] [ForeignKey(nameof(Score))]          public uint  ScoreID          { get; set; }
    [JsonIgnore] [ForeignKey(nameof(PrevScore))]      public uint? PrevScoreID      { get; set; }
    [JsonIgnore] [ForeignKey(nameof(RankedMap))]      public uint  RankedMapID      { get; set; }
    [JsonIgnore] [ForeignKey(nameof(SongDifficulty))] public uint  SongDifficultyID { get; set; }
    [JsonIgnore] [ForeignKey(nameof(Guild))]          public uint  GuildID          { get; set; }
#endif
}

/* Class only used by the server to query data with calculated fields */
#if GUILDSABER_SERVER
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class RankedScoreWithWeight
{
    ///////////////////////// SQL FormattableStrings ///////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    // ReSharper disable once UseRawString
    private const string JOIN_WEIGHT_QUERY = @"
                SELECT
                    *,
                    CASE
                        WHEN RScores.State <> 1 THEN 0
                        WHEN Points.IsSlopeEnabled = 1 THEN POWER(Points.SlopeMultiplier, RScores.RowNumber - 1)
                        ELSE 1
                    END AS Weight
                FROM (
                    SELECT
                        *,
                        ROW_NUMBER() OVER (PARTITION BY PlayerID ORDER BY IF(State = 1, 1, 2), RawPoints DESC, EffectiveScore DESC) AS RowNumber
                    FROM RankedScores
                    WHERE PointID = {0}
                ) AS RScores
                JOIN (
                    SELECT p.SlopeMultiplier, p.IsSlopeEnabled
                    FROM Points p
                    WHERE p.ID = {0}
                ) AS Points";

    /* Might cause issues if the 'CategoryRankedMap' table changes definition */
    // ReSharper disable once UseRawString
    private const string JOIN_WEIGHT_CATEGORY_QUERY = @"
                SELECT
                    *,
                    CASE
                        WHEN RScores.State <> 1 THEN 0
                        WHEN Points.IsSlopeEnabled = 1 THEN POWER(Points.SlopeMultiplier, RScores.RowNumber - 1)
                        ELSE 1
                    END AS Weight
                FROM (
                    SELECT
                        *,
                        ROW_NUMBER() OVER (PARTITION BY PlayerID ORDER BY IF(State = 1, 1, 2), RawPoints DESC, EffectiveScore DESC) AS RowNumber
                    FROM RankedScores AS RS
                    WHERE RS.PointID = {0}
                    AND EXISTS (
                        SELECT 1
                        FROM CategoryRankedMap AS CRM
                        WHERE CRM.RankedMapsID = RS.RankedMapID
                        AND CRM.CategoriesID = {1}
                    )
                ) AS RScores
                JOIN (
                    SELECT p.SlopeMultiplier, p.IsSlopeEnabled
                    FROM Points p
                    WHERE p.ID = {0}
                ) AS Points";

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public uint ID { get; set; }

    public uint  ScoreID          { get; set; }
    public uint? PrevScoreID      { get; set; }
    public uint  RankedMapID      { get; set; }
    public uint  PointID          { get; set; }
    public uint  PlayerID         { get; set; }
    public uint  SongDifficultyID { get; set; }
    public uint  GuildID          { get; set; }

    public EPassState m_PassState { get; set; }

    public uint  EffectiveScore { get; set; }
    public float RawPoints      { get; set; }

    public uint Rank { get; set; }

    /* Added Field */
    public float Weight    { get; set; }
    public uint  RowNumber { get; set; }

    public uint CreatedUnixTime  { get; set; }
    public uint ModifiedUnixTime { get; set; }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    public static FormattableString GetJoinSqlQuery(uint p_PointID, uint? p_CategoryID = null)
        => p_CategoryID is not null and not 0
            ? FormattableStringFactory.Create(JOIN_WEIGHT_CATEGORY_QUERY, p_PointID, p_CategoryID)
            : FormattableStringFactory.Create(JOIN_WEIGHT_QUERY,          p_PointID);
}
#endif
