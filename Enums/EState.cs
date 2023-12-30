namespace GuildSaber.Enums;

[Flags]
public enum EState
{
    UnVerified           = 0,
    Allowed              = 1 << 0,
    Denied               = 1 << 1,
    NeedConfirmation     = 1 << 2,
    MinScoreRequirement  = 1 << 3,
    ProhibitedModifiers  = 1 << 4,
    MissingModifiers     = 1 << 5,
    TooMuchPaused        = 1 << 6,
    NoFullCombo          = 1 << 7,
    ScoringTeamConfirmed = 1 << 8,
    ScoringTeamDenied    = 1 << 9,
    MissingTrackers      = 1 << 30,
    MissingRequirements  = MinScoreRequirement | ProhibitedModifiers | MissingModifiers | TooMuchPaused | NoFullCombo | MissingTrackers
}
