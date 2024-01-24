using GuildSaber.Enums;
using GuildSaber.Models;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
#endif

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class RankedMapWithScoreStruct
{
#if GUILDSABER_SERVER
    required public RankedMap RankedMap { get; set; }
#else
    public RankedMap RankedMap { get; set; } = null!;
#endif

    public RankedScore?  RankedScore  { get; set; }
    public SimplePoint[] SimplePoints { get; set; } = Array.Empty<SimplePoint>();
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class AddRankedMapApiStruct
{
    /// <summary>
    ///     That's another one
    /// </summary>
    public uint GuildID { get; set; }

#if GUILDSABER_SERVER
    [MinLength(40)] [MaxLength(40)]
#endif
    [DefaultValue("C4CCC41A43BB15F252B025F03BCE6F9C1DBBDBEB")]
    public string MapHash { get; set; } = string.Empty;
    [DefaultValue(9)]
    public EDifficulty Difficulty { get; set; } = EDifficulty.ExpertPlus;

    [DefaultValue(null)]
    public uint? GameModeID { get; set; }
    [DefaultValue("Standard")]
    public string? GameMode { get; set; }

    public RankedMap.ECustomModRatingFlag UsedModifiersModifierRating { get; set; } = RankedMap.ECustomModRatingFlag.None;
    [DefaultValue(null)]
    public RankedMap.Stars? ForcedStarRating { get; set; } = null;

    public ERankingState               RankingState { get; set; }
    public RankedMap.RequirementStruct Requirements { get; set; } = null!;

#if GUILDSABER_SERVER
    [Range(1, int.MaxValue)]
#endif
    [DefaultValue(null)]
    public uint? CategoryID { get; set; }

#if GUILDSABER_SERVER
    [Range(1, int.MaxValue)]
#endif
    [DefaultValue(null)]
    public uint? PlaylistID { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public struct EditRankedMapApiStruct
{
#if GUILDSABER_SERVER
    [Range(1, int.MaxValue)]
#endif
    public uint RankedMapID { get; set; }

    public ERankingState?               RankingState { get; set; }
    public RankedMap.RequirementStruct? Requirements { get; set; }
}
