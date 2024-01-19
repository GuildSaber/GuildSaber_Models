using GuildSaber.Models;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct.Leaderboard;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class PlayerLeaderboardApiStruct
{
#if GUILDSABER_SERVER
    required public Player Player { get; set; }
#else
    public Player Player { get; set; } = null!;
#endif

    public float Points { get; set; }
}
