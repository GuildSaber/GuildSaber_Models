#if GUILDSABER_SERVER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace GuildSaber.ApiStruct;

#if GUILDSABER_SERVER
[JsonConverter(typeof(StringEnumConverter))]
#endif
public enum EGuildSorters
{
    ID           = 0,
    Popularity   = 1,
    Name         = 2,
    CreationDate = 3,
    MapCount     = 4,
    MemberCount  = 5
}
