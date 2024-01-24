using System.Diagnostics.CodeAnalysis;
#if GUILDSABER_SERVER
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
#endif

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
#if GUILDSABER_SERVER
[PrimaryKey(nameof(UserID), nameof(SessionID))]
#endif
public class UserSession
{
    /* Primary Keys */
#if GUILDSABER_SERVER
    [ForeignKey(nameof(User))]
#endif
    public uint UserID { get;    set; }
    public uint SessionID { get; set; }

    /* Relationships */
    public ulong ExpirationUnixTime { get; set; }
    public bool  IsValid            { get; set; } = true;
}
