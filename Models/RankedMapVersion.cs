using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(RankedMapID), nameof(SongDifficultyID))]
#endif
public class RankedMapVersion
{
    public SongDifficulty? SongDifficulty { get; set; } = null;
    public uint            Version        { get; set; } = 1;

#if GUILDSABER_SERVER
    [JsonIgnore]                                      public RankedMap? RankedMap        { get; set; } = null;
    [JsonIgnore] [ForeignKey(nameof(RankedMap))]      public uint       RankedMapID      { get; set; }
    [JsonIgnore] [ForeignKey(nameof(SongDifficulty))] public uint       SongDifficultyID { get; set; }
#endif
}
