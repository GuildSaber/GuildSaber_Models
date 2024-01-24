using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class Song
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

    public string  Hash           { get; set; } = string.Empty;
    public string? BeatSaverKey   { get; set; }
    public string  Name           { get; set; } = string.Empty;
    public string  SongName       { get; set; } = string.Empty;
    public string  SongSubName    { get; set; } = string.Empty;
    public string  SongAuthorName { get; set; } = string.Empty;
    public string  MapperName     { get; set; } = string.Empty;

    public bool  IsAutoMapped { get; set; }
    public float BPM          { get; set; }
    public float Duration     { get; set; }

    public ulong UnixUploadedTime { get; set; }

    public string CoverURL
    {
        get => "https://eu.cdn.beatsaver.com/" + Hash + ".jpg";
    }

#if GUILDSABER_SERVER
    [JsonIgnore]
    public ICollection<SongDifficulty>? SongDifficulties { get; set; } = null;
#endif
}
