using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Tag
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

    public string  Name        { get; set; } = string.Empty;
    public string? Description { get; set; }

#if GUILDSABER_SERVER
    [JsonIgnore] public ICollection<RankedMap>? RankedMaps { get; set; } = null;
#endif
}
