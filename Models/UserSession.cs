using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
[PrimaryKey(nameof(UserID), nameof(SessionID))]
public class UserSession
{
    /* Primary Keys */
    [ForeignKey(nameof(User))]
    public uint UserID { get;    set; }
    public uint SessionID { get; set; }

    /* Relationships */
    public ulong ExpirationUnixTime { get; set; }
    public bool  IsValid            { get; set; } = true;
}
