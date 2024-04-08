namespace Arinc424;

/// <summary>
/// <c>Time Code (TIME CD)</c> character.
/// </summary>
/// <remarks>See section 5.131.</remarks>
public enum TimeCode : byte
{
    Unknown,
    /// <summary>
    /// Active continuously, including holidays.
    /// </summary>
    WithHolidays,
    /// <summary>
    /// Active continuously, excluding holidays.
    /// </summary>
    WithoutHolidays,
    /// <summary>
    /// Active non-continuously, refer to Continuation Record.
    /// </summary>
    NonContinuously,
    /// <summary>
    /// Active times announced by NOTAM.
    /// </summary>
    ByNotam,
    /// <summary>
    /// Active times are not specified in source documentation.
    /// </summary>
    NotSpecified,
    /// <summary>
    /// Active times are provided in Time of Operation format and exclude holidays.
    /// </summary>
    InOperationTimeWithoutHolidays,
    /// <summary>
    /// Active times are provided in Time of Operation format and include holidays.
    /// </summary>
    InOperationTimeWithHolidays
}
