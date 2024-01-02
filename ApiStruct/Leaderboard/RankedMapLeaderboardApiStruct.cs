using GuildSaber.Models;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct.Leaderboard;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class RankedMapLeaderboardApiStruct
{
    required public Player      Player      { get; set; }
    required public RankedScore RankedScore { get; set; }
}
