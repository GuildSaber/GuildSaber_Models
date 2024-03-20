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
    public string Name { get;     set; } = string.Empty;
    public float Number    { get; set; }
    public float Threshold { get; set; }

#if GUILDSABER_SERVER
    /* Ensure the RoleID can be deserialized from a request Body */
    [NotMapped]
    public string? DiscordRoleID
    {
        get => RoleID?.ToString();
        set => RoleID = string.IsNullOrEmpty(value) ? null : ulong.Parse(value);
    }

    /* Ensures the RoleID is a ulong in database, but a string when serialized as a JSON response */
    public ulong? RoleID { get; set; }
#else
    public string? DiscordRoleID { get; set; }
    public ulong?  RoleID        => DiscordRoleID == null ? null : ulong.Parse(DiscordRoleID);
#endif
}
