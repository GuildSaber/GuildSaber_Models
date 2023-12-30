using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(PlayerID), nameof(PointID))]
public class PlayerPointStat
{
    [ForeignKey(nameof(Player))]
    public uint PlayerID { get; set; }

    [ForeignKey(nameof(Point))]
    public uint PointID { get; set; }

    public Player? Player { get; set; } = null;
    public Point?  Point  { get; set; } = null;

    public float Value { get; set; }
}
