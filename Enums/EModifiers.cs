﻿namespace GuildSaber.Enums;

[Flags]
public enum EModifiers
{
    None               = 0,
    NoObstacles        = 1 << 0,
    NoBombs            = 1 << 1,
    NoFail             = 1 << 2,
    SlowerSong         = 1 << 3,
    BatteryEnergy      = 1 << 4,
    InstaFail          = 1 << 5,
    SmallNotes         = 1 << 6,
    ProMode            = 1 << 7,
    FasterSong         = 1 << 8,
    StrictAngles       = 1 << 9,
    DisappearingArrows = 1 << 10,
    GhostNotes         = 1 << 11,
    NoArrows           = 1 << 12,
    SuperFastSong      = 1 << 13,
    OldDots            = 1 << 14,
    OffPlatform        = 1 << 15,
    Unk                = 1 << 30
}
