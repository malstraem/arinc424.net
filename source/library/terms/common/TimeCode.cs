namespace Arinc424;

/**<summary>
<c>Time Code (TIME CD)</c> character.
</summary>
<remarks>See section 5.131.</remarks>*/
[Char, Transform<TimeCodeConverter, TimeCode>]
[Description("Time Code (TIME CD)")]
public enum TimeCode : byte
{
    Unknown,
    /**<summary>
    Active continuously, including holidays.
    </summary>*/
    [Map('C')] WithHolidays,
    /**<summary>
    Active continuously, excluding holidays.
    </summary>*/
    [Map('H')] WithoutHolidays,
    /**<summary>
    Active non-continuously, refer to Continuation Record.
    </summary>*/
    [Map('N')] NonContinuously,
    /**<summary>
    Active times announced by NOTAM.
    </summary>*/
    [Map('P')] ByNotam,
    /**<summary>
    Active times are not specified in source documentation.
    </summary>*/
    [Map('U')] Unspecified
}
