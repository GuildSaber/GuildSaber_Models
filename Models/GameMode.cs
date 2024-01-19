using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using System.ComponentModel.DataAnnotations;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class GameMode
{
    public static readonly string[] DEFAULT_GAMEMODES = { "Standard", "Lawless", "OneSaber", "90Degree", "360Degree", "NoArrows", "Generated360Degree", "Generated90Degree" };

#if GUILDSABER_SERVER
    [Key]
#endif
    public uint ID { get; set; }

#if GUILDSABER_SERVER
    [StringLength(128)]
#endif
    public string Name { get; set; } = string.Empty;
}
