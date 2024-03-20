using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(LevelID), nameof(CategoryID))]
#endif
public class LevelOverride
{
#if GUILDSABER_SERVER
    [ForeignKey(nameof(Level))]
#endif
    public uint LevelID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Category))]
#endif
    public uint CategoryID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }

    public string NameOverride      { get; set; } = string.Empty;
    public float  ThresholdOverride { get; set; }

#if GUILDSABER_SERVER
    /* Ensure the RoleID can be deserialized from a request Body */
    [NotMapped]
    public string? DiscordRoleIDOverride
    {
        get => RoleIDOverride?.ToString();
        set => RoleIDOverride = string.IsNullOrEmpty(value) ? null : ulong.Parse(value);
    }

    /* Ensures the RoleID is a ulong in database, but a string when serialized as a JSON response */
    public ulong? RoleIDOverride { get; set; }
#else
    public string? DiscordRoleIDOverride { get; set; }
    public ulong?  RoleIDOverride        => DiscordRoleIDOverride == null ? null : ulong.Parse(DiscordRoleIDOverride);
#endif
}
