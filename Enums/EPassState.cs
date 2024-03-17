namespace GuildSaber.Enums;

/// <summary>
///     The state of a ranked score
///     When a ranked score follows all the requirements, it is allowed
///     When a ranked score doesn't, one of the Missing Requirements is set
///     When a User leaves/gets kicked/gets banned from the guild, the score get the removed flag
///     If the ranked score needs to be confirmed, the score get the pending flag
///     When the ranked score that needs to be confirmed is confirmed, the score get the ScoringTeamConfirmed flag,
///     otherwise it get the ScoringTeamDenied flag
///     If the ScoringTeam decides to remove a ranked score, they can set the ScoringTeamDenied flag (so they can deny the
///     score, and it won't have any effect until it's redone)
/// </summary>
[Flags]
public enum EPassState
{
    UnVerified           = 0,
    Allowed              = 1 << 0,
    Removed              = 1 << 1, /* Removed is when the user leaves/gets kicked/gets banned from the guild */
    Pending              = 1 << 2, /* Currently pending confirmation from the ScoringTeam */
    MinScoreRequirement  = 1 << 3,
    ProhibitedModifiers  = 1 << 4,
    MissingModifiers     = 1 << 5,
    TooMuchPaused        = 1 << 6,
    NoFullCombo          = 1 << 7,
    ScoringTeamConfirmed = 1 << 8,
    ScoringTeamDenied    = 1 << 9, /* State in which scores the team don't believe is valid should have */
    MissingTrackers      = 1 << 30,

    UnPassed            = 1 << 31, /* This should NEVER be set on a RankedScore, it's only for query purpose */
    AllAllowed          = Allowed             | ScoringTeamConfirmed,
    AllDenied           = Removed             | ScoringTeamDenied,
    MissingRequirements = MinScoreRequirement | ProhibitedModifiers | MissingModifiers    | TooMuchPaused | NoFullCombo | MissingTrackers,
    All                 = AllAllowed          | AllDenied           | MissingRequirements | Pending       | UnPassed
}
