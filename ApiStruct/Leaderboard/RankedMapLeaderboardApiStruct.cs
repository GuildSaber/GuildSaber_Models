using GuildSaber.Models;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct.Leaderboard;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class RankedMapLeaderboardApiStruct
{
#if GUILDSABER_SERVER
    required public Player Player { get; set; }
#else
    public Player Player { get; set; } = null!;
#endif

#if GUILDSABER_SERVER
    required public RankedScore RankedScore { get; set; }
#else
    public RankedScore RankedScore { get; set; } = null!;
#endif
}
