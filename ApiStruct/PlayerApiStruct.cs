﻿using GuildSaber.Models;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public struct PlayerAtMeStruct
{
    public User                User;
    public Player              Player;
    public ICollection<Member> MemberList;
    public bool                IsGuildSaberManager;
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public struct PlayerPointStatsStruct
{
    public uint  PlayerID;
    public uint  PointID;
    public uint  Rank;
    public uint  ValidPassCount;
    public float PointValue;
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public struct PlayerResponseStruct
{
    public Player                                  Player;
    public ICollection<GuildWithSimplifiedPoints>? Guilds;
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GuildWithSimplifiedPoints : Guild
{
    public List<SimplePoint>? SimplifiedPoints { get; set; }
}
