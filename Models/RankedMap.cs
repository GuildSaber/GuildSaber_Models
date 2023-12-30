using GuildSaber.Defaults;
using GuildSaber.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class RankedMap
{
    [Flags]
    public enum ECustomModifierRating
    {
        None          = 0,
        SlowSong      = 1 << 0,
        FasterSong    = 1 << 1,
        SuperFastSong = 1 << 2
    }

    [Key]
    public uint ID { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    public          ERankingState             RankingState { get; set; }
    required public RequirementStruct         Requirements { get; set; }
    required public RankedMapDifficultyRating Rating       { get; set; }

    public uint UnixCreationTime { get; set; }
    public uint UnixEditTime     { get; set; }

    [JsonIgnore]
    public Guild? Guild { get; set; }

    public ICollection<RankedMapVersion>? RankedMapVersions { get; set; }
    [JsonIgnore]
    public ICollection<Tag>? Tags { get; set; }
    [JsonIgnore]
    public ICollection<RankedScore>? RankedScores { get; set; }
    [JsonIgnore]
    public ICollection<Playlist>? Playlists { get; set; }
    [JsonIgnore]
    public ICollection<Category>? Categories { get; set; }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    [Owned]
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

    [Owned]
    public class RankedMapDifficultyRating
    {
        [JsonIgnore]
        required public ModifiersRating m_Modifiers { get; set; }

        public ECustomModifierRating CustomModifiersRating { get; set; } = ECustomModifierRating.None;

        public InRating Default { get; set; } = new();

        [NotMapped]
        public ModifiersRating? Modifiers
        {
            get
            {
                if (CustomModifiersRating == ECustomModifierRating.None)
                    return null;

                var l_ReturnValue = new ModifiersRating();

                foreach (var p_Flags in Enum.GetValues(typeof(ECustomModifierRating)).Cast<ECustomModifierRating>().Where(p_Value => (p_Value & CustomModifiersRating) != 0))
                {
                    switch (p_Flags)
                    {
                        case ECustomModifierRating.SlowSong:
                            l_ReturnValue.SlowerSong = new InRating { Stars = m_Modifiers?.SlowerSong?.Stars ?? new Stars() };
                            break;
                        case ECustomModifierRating.FasterSong:
                            l_ReturnValue.FasterSong = new InRating { Stars = m_Modifiers?.FasterSong?.Stars ?? new Stars() };
                            break;
                        case ECustomModifierRating.SuperFastSong:
                            l_ReturnValue.SuperFastSong = new InRating { Stars = m_Modifiers?.SuperFastSong?.Stars ?? new Stars() };
                            break;
                        case ECustomModifierRating.None:
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                return l_ReturnValue;
            }
        }
    }

    [Owned]
    public class ModifiersRating
    {
        [NotNull] public InRating? SlowerSong    { get; set; }
        [NotNull] public InRating? FasterSong    { get; set; }
        [NotNull] public InRating? SuperFastSong { get; set; }
    }

    [Owned]
    public class Stars
    {
        [JsonIgnore] public float m_Difficulty { get; set; }
        [JsonIgnore] public float m_Acc        { get; set; }

        [JsonIgnore] public float HiddenScaling_Difficulty { get; set; }
        [JsonIgnore] public float HiddenScaling_Acc        { get; set; }

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
    }

    [Owned]
    public class InRating
    {
        [JsonIgnore] public float Pass         { get; set; } = 0;
        [JsonIgnore] public float Acc          { get; set; } = 0;
        [JsonIgnore] public float Tech         { get; set; } = 0;
        [JsonIgnore] public float PredictedAcc { get; set; } = 0;

        public Stars Stars { get; set; } = new();
    }
}
