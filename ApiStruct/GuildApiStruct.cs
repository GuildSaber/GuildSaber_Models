using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.ApiStruct;

[SuppressMessage("ReSharper", "InconsistentNaming")]
public class GuildStats
{
    public uint MemberCount      { get; set; }
    public uint RankedMapCount   { get; set; }
    public uint RankedScoreCount { get; set; }
}
