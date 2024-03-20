using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(PlayerID), nameof(GuildID), nameof(CategoryID))]
#endif
public class PlayerCategoryLevelStat
{
#if GUILDSABER_SERVER
    [ForeignKey(nameof(Player))]
#endif
    public uint PlayerID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Guild))]
#endif
    public uint GuildID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Category))]
#endif
    public uint CategoryID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(Level))]
#endif
    public uint? LevelID { get; set; }

#if GUILDSABER_SERVER
    [ForeignKey(nameof(NextLevel))]
#endif
    public uint? NextLevelID { get; set; }

    public float Xp { get; set; }

    public LevelOverride? Level { get; set; } = null;
    public LevelOverride? NextLevel    { get; set; } = null;
}
