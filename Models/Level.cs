using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(ID), nameof(GuildID))]
public class Level
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public uint ID { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    public uint Value { get; set; }

    public ulong DiscordID { get; set; }
}
