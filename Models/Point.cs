using GuildSaber.Defaults;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;

namespace GuildSaber.Models;

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class Point : SimplePoint
{
    [NotMapped] [JsonIgnore] private List<(double, double)>? m_DeserializedAccCurve;
    [NotMapped] [JsonIgnore] private List<(double, double)>? m_DeserializedDiffCurve;


    public ModifierValuesStruct ModifierValues { get; set; } = new();

    public float DifficultyScale { get; set; } = 1.0f;
    public float AccuracyScale   { get; set; } = 1.0f;
    public float SlopeMultiplier { get; set; } = 0.965f;
    public bool  IsSlopeEnabled  { get; set; }

    /// <summary>
    ///     When enabled, the curve will be used to calculate the points for the score.
    ///     When disabled, the curve will not be used, and so the points wont depend on the accuracy.
    /// </summary>
    public bool IsAccCurveEnabled { get;                     set; } = false;
    public float DefaultAverageAccForPointCalculation { get; set; } = 0.95f;

    [MaxLength(512)]
    public string DiffCurve { get; set; } = SerializeCurve(PointsDefault.s_DefaultBLPassCurve);

    [MaxLength(512)]
    public string AccCurve { get;           set; } = SerializeCurve(PointsDefault.s_DefaultAccCurve);
    [JsonIgnore] public Guild? Guild { get; set; } = null;

    [NotMapped] [JsonIgnore] public List<(double, double)> DeserializedAccCurve  { get => m_DeserializedAccCurve ??= DeserializeCurve(AccCurve); }
    [NotMapped] [JsonIgnore] public List<(double, double)> DeserializedDiffCurve { get => m_DeserializedDiffCurve ??= DeserializeCurve(DiffCurve); }

    public static string SerializeCurve(IEnumerable<(double, double)> p_Curve)
        => string.Join(",", p_Curve.Select(p => $"({p.Item1.ToString(CultureInfo.InvariantCulture)},{p.Item2.ToString(CultureInfo.InvariantCulture)})"));

    private static List<(double, double)> DeserializeCurve(string p_Curve)
        => p_Curve.Split("),").Select(p =>
        {
            var parts = p.Trim('(', ')').Split(',');
            return (double.Parse(parts[0], CultureInfo.InvariantCulture), double.Parse(parts[1], CultureInfo.InvariantCulture));
        }).ToList();


    [Owned]
    public class ModifierValuesStruct
    {
        public float OffPlatform   { get; set; } = -0.50f;
        public float NoFail        { get; set; } = -0.50f;
        public float NoBombs       { get; set; } = -0.10f;
        public float NoArrows      { get; set; } = -0.50f;
        public float NoObstacles   { get; set; } = -0.20f;
        public float SlowerSong    { get; set; } = -0.30f;
        public float FasterSong    { get; set; } = 0.08f;
        public float SuperFastSong { get; set; } = 0.36f;
        public float GhostNotes    { get; set; } = 0.04f;
        public float Disappearing  { get; set; } = 0.00f;
        public float BatteryEnergy { get; set; } = 0.00f;
        public float InstaFail     { get; set; } = 0.00f;
        public float SmallNotes    { get; set; } = 0.00f;
        public float ProMode       { get; set; } = 0.00f;
        public float StrictAngles  { get; set; } = 0.00f;
        public float OldDots       { get; set; } = 0.00f;
    }
}

[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "CollectionNeverUpdated.Global")]
public class SimplePoint
{
    [Key]
    public uint ID { get; set; }

    [ForeignKey(nameof(Guild))]
    public uint GuildID { get; set; }

    [MinLength(2)] [MaxLength(15)] public string Name { get; set; } = string.Empty;
}
