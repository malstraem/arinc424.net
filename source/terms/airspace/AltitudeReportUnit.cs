namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>FIR/UIR ATC Reporting Units Altitude (RUA)</c> character.
/// </summary>
/// <remarks>See section 5.123.</remarks>
[Char, Transform<AltitudeReportUnitConverter>]
[Description("FIR/UIR ATC Reporting Units Altitude (RUA)")]
public enum AltitudeReportUnit : byte
{
    Unknown,
    [Map('0')] Unspecified,
    [Map('1')] Level,
    [Map('2')] Meters,
    [Map('3')] Feet
}
