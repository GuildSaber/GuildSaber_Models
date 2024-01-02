using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GuildSaber.ApiStruct;

[JsonConverter(typeof(StringEnumConverter))]
public enum EGuildSorters
{
    ID           = 0,
    Popularity   = 1,
    Name         = 2,
    CreationDate = 3,
    MapCount     = 4,
    MemberCount  = 5
}
