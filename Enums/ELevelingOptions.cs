namespace GuildSaber.Enums;

[Flags]
public enum ELevelingOptions : byte
{
    XpBased          = 0,
    RatingBased      = 1 << 0,
    CategoryLeveling = 1 << 1,
}
