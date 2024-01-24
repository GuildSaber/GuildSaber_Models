using GuildSaber.Defaults;
using GuildSaber.Enums;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
#endif
#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class RankedMap
{
    [Flags]
    public enum ECustomModRatingFlag
    {
        None          = 0,
        SlowSong      = 1 << 0,
        FasterSong    = 1 << 1,
        SuperFastSong = 1 << 2
    }

#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }

    public ERankingState RankingState { get; set; }

#if GUILDSABER_SERVER
    required public RequirementStruct         Requirements { get; set; }
    required public RankedMapDifficultyRating Rating       { get; set; }
#else
    public RequirementStruct         Requirements { get; set; } = null!;
    public RankedMapDifficultyRating Rating       { get; set; } = null!;
#endif

    public uint UnixCreationTime { get; set; }
    public uint UnixEditTime     { get; set; }

#if GUILDSABER_SERVER
    [JsonIgnore]
    public Guild? Guild { get; set; }
#endif

#if GUILDSABER_SERVER
    public ICollection<RankedMapVersion>? RankedMapVersions { get; set; }
#else
    public RankedMapVersion[]? RankedMapVersions { get; set; }
#endif

#if GUILDSABER_SERVER
    [JsonIgnore]
    public ICollection<Tag>? Tags { get; set; }
    [JsonIgnore]
    public ICollection<RankedScore>? RankedScores { get; set; }
    [JsonIgnore]
    public ICollection<Playlist>? Playlists { get; set; }
    [JsonIgnore]
    public ICollection<Category>? Categories { get; set; }
#endif

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

#if GUILDSABER_SERVER
    [Owned]
#endif
    public class RequirementStruct
    {
        [DefaultValue(false)] public bool DoesNeedConfirmation { get; set; } = false;
        [DefaultValue(false)] public bool DoesNeedFullCombo    { get; set; } = false;

        [DefaultValue(-1.0f)] public float MaxPauseDuration { get; set; } = -1.0f;

        [DefaultValue(ModifiersDefault.DEFAULT_PROHIBITED_MODIFIERS)]
        public EModifiers ProhibitedModifiers { get; set; } = ModifiersDefault.DEFAULT_PROHIBITED_MODIFIERS;
        public EModifiers MandatoryModifiers { get;  set; } = EModifiers.None;

        public float MinAccuracy { get; set; }
    }

#if GUILDSABER_SERVER
    [Owned]
#endif
    public class RankedMapDifficultyRating
    {
#if GUILDSABER_SERVER
        [JsonIgnore]
        required public ModifiersRating Modifiers { get; set; }
#endif

        public ECustomModRatingFlag EnabledCustomModRatingFlag { get; set; } = ECustomModRatingFlag.None;

        public InRating Default { get; set; } = new();
    }

#if GUILDSABER_SERVER
    [Owned]
#endif
    /* [NotNull] Are for EFCore design time */
    public class ModifiersRating
    {
#if GUILDSABER_SERVER
        [NotNull]
#endif
        public InRating? SlowerSong { get; set; }
#if GUILDSABER_SERVER
        [NotNull]
#endif
        public InRating? FasterSong { get; set; }
#if GUILDSABER_SERVER
        [NotNull]
#endif
        public InRating? SuperFastSong { get; set; }
    }

#if GUILDSABER_SERVER
    [Owned]
#endif
    public class Stars
    {
#if GUILDSABER_SERVER
        [JsonIgnore] public float m_Difficulty { get; set; }
        [JsonIgnore] public float m_Acc        { get; set; }

        [JsonIgnore] public float HiddenScaling_Difficulty { get; set; }
        [JsonIgnore] public float HiddenScaling_Acc        { get; set; }
#endif

#if GUILDSABER_SERVER
        [Range(0, float.MaxValue)] [DefaultValue(null)] [NotMapped] public decimal? Difficulty
        {
            get => Math.Round((decimal)(m_Difficulty * HiddenScaling_Difficulty), 2);
            init
            {
                if (value is null) return;

                m_Difficulty = (float)value;
            }
        }

        [Range(0, float.MaxValue)] [DefaultValue(null)] [NotMapped] public decimal? Acc
        {
            get => Math.Round((decimal)(m_Acc * HiddenScaling_Acc), 2);
            init
            {
                if (value is null) return;

                m_Acc = (float)value;
            }
        }

#else
        public decimal? Difficulty { get; set; }
        public decimal? Acc        { get; set; }
#endif
    }

#if GUILDSABER_SERVER
    [Owned]
#endif
    public class InRating
    {
        public Stars Stars { get; set; } = new();
#if GUILDSABER_SERVER
        [JsonIgnore] public float Pass         { get; set; } = 0;
        [JsonIgnore] public float Acc          { get; set; } = 0;
        [JsonIgnore] public float Tech         { get; set; } = 0;
        [JsonIgnore] public float PredictedAcc { get; set; } = 0;
#endif
    }
}
