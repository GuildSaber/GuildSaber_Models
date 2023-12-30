using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class SongDifficultyStats
{
    [Key]
    public uint ID { get; set; }

    public uint   MaxScore       { get; set; }
    public float  NoteJumpSpeed  { get; set; }
    public uint   NoteCount      { get; set; }
    public uint   BombCount      { get; set; }
    public uint   ObstacleCount  { get; set; }
    public float  NotesPerSecond { get; set; }
    public double Duration       { get; set; }

    [JsonIgnore]
    public ICollection<SongDifficulty>? SongDifficulties { get; set; } = null;
}
