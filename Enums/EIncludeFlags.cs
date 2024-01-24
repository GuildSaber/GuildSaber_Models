﻿#if GUILDSABER_SERVER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace GuildSaber.Enums;

#if GUILDSABER_SERVER
[JsonConverter(typeof(StringEnumConverter))]
#endif
[Flags]
public enum EIncludeFlags : ulong
{
    None                     = 0,
    Categories               = 1 << 0,
    CategoryLevels           = 1 << 1,
    GameModes                = 1 << 2,
    Guilds                   = 1 << 3,
    Levels                   = 1 << 4,
    Members                  = 1 << 5,
    GuildBoosts              = 1 << 6,
    Players                  = 1 << 7,
    PlayerCategoryPointStats = 1 << 8,
    PlayerPointStats         = 1 << 9,
    Playlists                = 1 << 10,
    Points                   = 1 << 11,
    RankedMaps               = 1 << 12,
    RankedScores             = 1 << 13,
    RankedMapVersions        = 1 << 14,
    Scores                   = 1 << 15,
    HitTrackers              = 1 << 16,
    WinTrackers              = 1 << 17,
    AccuracyTrackers         = 1 << 18,
    ScoreGraphTrackers       = 1 << 19,
    Songs                    = 1 << 20,
    SongDifficulties         = 1 << 21,
    SongDifficultyStats      = 1 << 22,
    Tags                     = 1 << 23,
    Users                    = 1 << 24,
    UserSessions             = 1 << 25,
    PrevScores               = 1 << 26,
    PrevScoreTrackers        = 1 << 27,
    All                      = ~0ul
}
