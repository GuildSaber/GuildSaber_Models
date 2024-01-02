using GuildSaber.Enums;
using GuildSaber.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class AddRankedMapApiStruct
{
    /// <summary>
    ///     That's another one
    /// </summary>
    public uint GuildID { get; set; }

    [MinLength(40)] [MaxLength(40)] [DefaultValue("C4CCC41A43BB15F252B025F03BCE6F9C1DBBDBEB")]
    public string MapHash { get; set; } = string.Empty;
    [DefaultValue(9)]
    public SongDifficulty.EDifficulty Difficulty { get; set; } = SongDifficulty.EDifficulty.ExpertPlus;

    [DefaultValue(null)]
    public uint? GameModeID { get; set; }
    [DefaultValue("Standard")]
    public string? GameMode { get; set; }

    public RankedMap.ECustomModifierRating UsedModifiersModifierRating { get; set; } = RankedMap.ECustomModifierRating.None;
    [DefaultValue(null)]
    public RankedMap.Stars? ForcedStarRating { get; set; } = null;

    public ERankingState               RankingState { get; set; }
    public RankedMap.RequirementStruct Requirements { get; set; } = null!;

    [Range(1, int.MaxValue)] [DefaultValue(null)]
    public uint? CategoryID { get; set; }
    [Range(1, int.MaxValue)] [DefaultValue(null)]
    public uint? PlaylistID { get; set; }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public struct EditRankedMapApiStruct
{
    [Range(1, int.MaxValue)]
    public uint RankedMapID { get; set; }

    public ERankingState?               RankingState { get; set; }
    public RankedMap.RequirementStruct? Requirements { get; set; }
}
