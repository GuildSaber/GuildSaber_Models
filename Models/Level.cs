using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class Level
{
#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }

#if GUILDSABER_SERVER
    [StringLength(32)]
#endif
    public string Name { get;      set; } = string.Empty;
    public float  Value     { get; set; }
    public float  Threshold { get; set; }
    public ulong? DiscordID { get; set; }
}
