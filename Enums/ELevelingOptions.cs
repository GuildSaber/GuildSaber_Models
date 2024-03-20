namespace GuildSaber.Enums;

[Flags]
public enum ELevelingOptions
{
    Disabled         = 0,
    XpBased          = 1 << 0,
    RatingBased      = 1 << 1,
    CategoryLeveling = 1 << 2,
    CategoryXp       = 1 << 3,
    CategoryRating   = 1 << 4,
}
