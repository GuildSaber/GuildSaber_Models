using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(RankedMapID), nameof(SongDifficultyID))]
public class RankedMapVersion
{
    [JsonIgnore]
    [ForeignKey(nameof(RankedMap))]
    public uint RankedMapID { get; set; }

    [JsonIgnore]
    [ForeignKey(nameof(SongDifficulty))]
    public uint SongDifficultyID { get; set; }

    public uint Version { get; set; } = 1;

    [JsonIgnore]
    public RankedMap? RankedMap { get;           set; } = null;
    public SongDifficulty? SongDifficulty { get; set; } = null;
}
