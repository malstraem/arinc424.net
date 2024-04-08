namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>FIR/UIR ATC Reporting Units Altitude (RUA)</c> character.
/// </summary>
/// <remarks>See section 5.123.</remarks>
public enum AltitudeReportUnit : byte
{
    Unknown,
    NotSpecified,
    Level,
    Meters,
    Feet
}
