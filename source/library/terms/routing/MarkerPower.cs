namespace Arinc424.Routing.Terms;

/// <summary>
/// <c>High/Low (HIGH/LOW)</c> character.
/// </summary>
/// <remarks>See section 5.113.</remarks>
[Char, Transform<MarkerPowerConverter, MarkerPower>]
[Description("High/Low (HIGH/LOW)")]
public enum MarkerPower : byte
{
    Unknown,
    [Map('L')] Low,
    [Map('H')] High
}
