#if GUILDSABER_SERVER
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
#endif

namespace GuildSaber.Enums;

#if GUILDSABER_SERVER
[JsonConverter(typeof(StringEnumConverter))]
#endif
public enum ESorter
{
    Points     = 0,
    Time       = 1,
    EditTime   = 2,
    Accuracy   = 3,
    Score      = 4,
    Rank       = 5,
    Difficulty = 6
}
