using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Playlist
{
    [Key]
    public uint ID { get; set; }

    public string  Name        { get; set; } = string.Empty;
    public string? Description { get; set; }

    public uint Color { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }
    public Guild? Guild { get; set; } = null;

    [JsonIgnore]
    public ICollection<RankedMap>? RankedMaps { get; set; } = null;
}
