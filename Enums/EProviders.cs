#if GUILDSABER_SERVER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace GuildSaber.Enums;

#if GUILDSABER_SERVER
[JsonConverter(typeof(StringEnumConverter))]
#endif
public enum EProviders
{
    Discord    = 0,
    BeatLeader = 1
}
