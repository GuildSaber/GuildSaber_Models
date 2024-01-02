using GuildSaber.Models;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct.Leaderboard;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerLeaderboardApiStruct
{
    required public Player Player { get; set; }
    public          float  Points { get; set; }
}
