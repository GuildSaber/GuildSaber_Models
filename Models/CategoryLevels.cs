using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class CategoryLevels
{
    [Key]
    public uint ID { get; set; }

    [ForeignKey(nameof(Category))]
    public uint CategoryID { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    public uint  Value     { get; set; }
    public ulong DiscordID { get; set; }
}
