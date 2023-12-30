using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(PlayerID), nameof(PointID), nameof(CategoryID))]
public class PlayerCategoryPointStat
{
    [ForeignKey(nameof(Player))]
    public uint PlayerID { get; set; }

    [ForeignKey(nameof(Point))]
    public uint PointID { get; set; }

    [ForeignKey(nameof(Category))]
    public uint CategoryID { get; set; }

    public float Value { get; set; }

    public Player?   Player   { get; set; } = null;
    public Point?    Point    { get; set; } = null;
    public Category? Category { get; set; } = null;
}
