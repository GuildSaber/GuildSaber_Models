using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class GameMode
{
    public static readonly string[] DEFAULT_GAMEMODES = { "Standard", "Lawless", "OneSaber", "90Degree", "360Degree", "NoArrows", "Generated360Degree", "Generated90Degree" };

    [Key]
    public uint ID { get; set; }

    [StringLength(128)] public string Name { get; set; } = string.Empty;
}
