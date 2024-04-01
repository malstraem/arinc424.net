namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>FIR/UIR ATC Reporting Units Speed (RUS)</c> character.
/// </summary>
/// <remarks>See section 5.122.</remarks>
public enum SpeedReportUnit : byte
{
    Unknown,
    /// <summary>
    /// Not specified.
    /// </summary>
    NotSpecified,
    /// <summary>
    /// TAS in Knots.
    /// </summary>
    Knots,
    /// <summary>
    /// TAS in Mach.
    /// </summary>
    Mach,
    /// <summary>
    /// TAS in Kilometers/hr
    /// </summary>
    KilometersPerHour
}
