using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(PlayerID), nameof(PointID), nameof(CategoryID))]
#endif
public class PlayerCategoryPointStat
{
#if GUILDSABER_SERVER
    [ForeignKey(nameof(Player))]
#endif
    public uint PlayerID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Point))]
#endif
    public uint PointID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Category))]
#endif
    public uint CategoryID { get; set; }

    public float Value { get; set; }

    public Player?   Player   { get; set; } = null;
    public Point?    Point    { get; set; } = null;
    public Category? Category { get; set; } = null;
}
