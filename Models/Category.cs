using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Category
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get;             set; }
    public string  Name        { get; set; } = string.Empty;
    public string? Description { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }
    public Guild? Guild { get; set; } = null;

    public ICollection<RankedMap>?      RankedMaps     { get; set; }
    public ICollection<LevelOverride>? CategoryLevels { get; set; }
}
