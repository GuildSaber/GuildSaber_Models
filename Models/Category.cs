using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[SuppressMessage("ReSharper", "ClassWithVirtualMembersNeverInherited.Global")]
public class Category
{
    [Key]
    public uint ID { get;             set; }
    public string  Name        { get; set; } = string.Empty;
    public string? Description { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }
    public Guild? Guild { get; set; } = null;

    public ICollection<RankedMap>?      RankedMaps     { get; set; }
    public ICollection<CategoryLevels>? CategoryLevels { get; set; }
}
