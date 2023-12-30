using GuildSaber.Enums;
using System.Text;

namespace GuildSaber.Utils;

public static class ModifiersUtils
{
    private static readonly char[] s_Separator = { ',' };

    public static EModifiers StringToModifiers(string? p_Input)
    {
        if (p_Input is null) return 0;

        var l_Mods = p_Input.Split(s_Separator, StringSplitOptions.RemoveEmptyEntries);

        return (EModifiers)l_Mods.Aggregate<string, uint>(0,
            (p_Accumulator, p_Modifier) => p_Accumulator | p_Modifier switch
            {
                "NO" => (UInt32)EModifiers.NoObstacles,
                "NB" => (UInt32)EModifiers.NoBombs,
                "NF" => (UInt32)EModifiers.NoFail,
                "SS" => (UInt32)EModifiers.SlowerSong,
                "BE" => (UInt32)EModifiers.BatteryEnergy,
                "IF" => (UInt32)EModifiers.InstaFail,
                "SC" => (UInt32)EModifiers.SmallNotes,
                "PM" => (UInt32)EModifiers.ProMode,
                "FS" => (UInt32)EModifiers.FasterSong,
                "SA" => (UInt32)EModifiers.StrictAngles,
                "DA" => (UInt32)EModifiers.DisappearingArrows,
                "GN" => (UInt32)EModifiers.GhostNotes,
                "NA" => (UInt32)EModifiers.NoArrows,
                "SF" => (UInt32)EModifiers.SuperFastSong,
                "OD" => (UInt32)EModifiers.OldDots,
                "OP" => (UInt32)EModifiers.OffPlatform,
                _    => (UInt32)EModifiers.Unk
            });
    }

    public static string ModifiersToString(EModifiers p_Modifiers, bool p_PutNone = false)
    {
        var l_Result = new StringBuilder();

        /* Get all flags in the parameter */
        foreach (var l_Modifier in Enum.GetValues(typeof(EModifiers)).Cast<EModifiers>().Where(p_Value => (p_Value & p_Modifiers) != 0))
        {
            l_Result.Append(l_Modifier switch
            {
                EModifiers.NoObstacles        => "NO,",
                EModifiers.NoBombs            => "NB,",
                EModifiers.NoFail             => "NF,",
                EModifiers.SlowerSong         => "SS,",
                EModifiers.BatteryEnergy      => "BE,",
                EModifiers.InstaFail          => "IF,",
                EModifiers.SmallNotes         => "SC,",
                EModifiers.ProMode            => "PM,",
                EModifiers.FasterSong         => "FS,",
                EModifiers.StrictAngles       => "SA,",
                EModifiers.DisappearingArrows => "DA,",
                EModifiers.GhostNotes         => "GN,",
                EModifiers.NoArrows           => "NA,",
                EModifiers.SuperFastSong      => "SF,",
                EModifiers.OldDots            => "OD,",
                EModifiers.OffPlatform        => "OP,",
                EModifiers.Unk                => "UNK,",
                _                             => "NANI,"
            });
        }

        if (p_PutNone && p_Modifiers == 0) l_Result.Append("None,");
        if (l_Result.Length > 0) l_Result.Remove(l_Result.Length - 1, 1);

        return l_Result.Length > 0 ? l_Result.ToString() : string.Empty;
    }
}
