﻿using GuildSaber.Enums;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class Guild
{
    public Guild() { }

    public Guild(Guild p_Guild, uint? p_RankedMapCount, uint? p_MemberCount)
    {
        ID                   = p_Guild.ID;
        Name                 = p_Guild.Name;
        SmallName            = p_Guild.SmallName;
        Description          = p_Guild.Description;
        Color                = p_Guild.Color;
        Type                 = p_Guild.Type;
        JoinRequirements     = p_Guild.JoinRequirements;
        RankedScores         = p_Guild.RankedScores;
        RankedMaps           = p_Guild.RankedMaps;
        Members              = p_Guild.Members;
        Playlists            = p_Guild.Playlists;
        Points               = p_Guild.Points;
        Levels               = p_Guild.Levels;
        CategoryLevels       = p_Guild.CategoryLevels;
        GuildBoostCollection = p_Guild.GuildBoostCollection;
        UnixCreationTime     = p_Guild.UnixCreationTime;
        InviteCode           = p_Guild.InviteCode;
        Categories           = p_Guild.Categories;
        CategoryLevels       = p_Guild.CategoryLevels;

        RankedMapCount = p_RankedMapCount;
        MemberCount    = p_MemberCount;
    }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    [Key]
    public uint ID { get; set; }

    [MinLength(5)] [MaxLength(50)] public string Name      { get; set; } = string.Empty;
    [MinLength(2)] [MaxLength(6)]  public string SmallName { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;
    public uint   Color       { get; set; }

    public EGuildType            Type             { get; set; } = EGuildType.Unverified;
    public GuildJoinRequirements JoinRequirements { get; set; } = new();
    public GuildFilters          Filters          { get; set; } = new();

    public ICollection<Category>? Categories { get; set; }

    [JsonIgnore]
    public ICollection<RankedScore>? RankedScores { get; set; }
    [JsonIgnore]
    public ICollection<RankedMap>? RankedMaps { get; set; }
    [JsonIgnore]
    public ICollection<Member>? Members { get; set; }
    [JsonIgnore]
    public ICollection<Playlist>? Playlists { get; set; }
    [JsonIgnore]
    public ICollection<Point>? Points { get; set; }
    [JsonIgnore]
    public ICollection<Level>? Levels { get; set; }
    [JsonIgnore]
    public ICollection<CategoryLevels>? CategoryLevels { get; set; }
    [JsonIgnore]
    public ICollection<GuildBoosts>? GuildBoostCollection { get; set; }

    public                  ulong   UnixCreationTime { get; set; }
    [MaxLength(255)] public string? InviteCode       { get; set; }

    ////////////////////////////////////////////////////////////////////////////
    ////////////////////////////////////////////////////////////////////////////

    [NotMapped] public uint? RankedMapCount { get; set; }
    [NotMapped] public uint? MemberCount    { get; set; }

    [Owned]
    public class GuildJoinRequirements
    {
        [Flags]
        public enum ERequirements
        {
            None             = 0,
            Submission       = 1 << 0,
            MinRank          = 1 << 1,
            MaxRank          = 1 << 2,
            MinPP            = 1 << 3,
            MaxPP            = 1 << 4,
            AccountAgeUnix   = 1 << 5,
            NeedProfileFetch = MinRank | MaxRank | MinPP | MaxPP | AccountAgeUnix
        }

        public ERequirements Requirements   { get; set; } = ERequirements.None;
        public uint          MinRank        { get; set; } = 0;
        public uint          MaxRank        { get; set; } = 0;
        public uint          MinPP          { get; set; } = 0;
        public uint          MaxPP          { get; set; } = 0;
        public uint          AccountAgeUnix { get; set; } = 0;
    }

    [Owned]
    public class GuildFilters
    {
        public uint  MinDifficulty  { get; set; } = 0;
        public uint  MaxDifficulty  { get; set; } = 32;
        public float DifficultyStep { get; set; } = 1f;

        public uint MinBPM  { get; set; } = 0;
        public uint MaxBPM  { get; set; } = 1000;
        public uint BPMStep { get; set; } = 10;

        public uint MinDuration  { get; set; } = 0;
        public uint MaxDuration  { get; set; } = 1000;
        public uint DurationStep { get; set; } = 10;
    }
}
