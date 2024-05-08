namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>FIR/UIR ATC Reporting Units Speed (RUS)</c> character.
/// </summary>
/// <remarks>See section 5.122.</remarks>
[Char, Description("FIR/UIR ATC Reporting Units Speed (RUS)")]
public enum SpeedReportUnit : byte
{
    Unknown,
    /// <summary>
    /// Not specified.
    /// </summary>
    [Map('0')] Unspecified,
    /// <summary>
    /// TAS in Knots.
    /// </summary>
    [Map('1')] Knots,
    /// <summary>
    /// TAS in Mach.
    /// </summary>
    [Map('2')] Mach,
    /// <summary>
    /// TAS in Kilometers/hr.
    /// </summary>
    [Map('3')] KilometersPerHour
}
