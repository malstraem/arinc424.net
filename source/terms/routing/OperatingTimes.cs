namespace Arinc424.Routing.Terms;

/// <summary>
/// <c>Special Activity Area Operating Times</c> field.
/// </summary>
/// <remarks>See section 5.282.</remarks>
[String, Flags]
public enum OperatingTimes : ushort
{
    Unknown = 0,
    [Map('C')] ContinuousDays = 1,
    [Map('D')] Weekdays = 1 << 1,
    [Map('E')] Weekends = 1 << 2,
    [Map('O')] OtherDays = 1 << 3,
    [Map('U')] DaysUnspecified = 1 << 4,

    [Offset]
    [Map('H')] WithHolidays = 1 << 5,
    [Map('X')] WithoutHolidays = 1 << 6,
    [Map('U')] HolidaysUnspecified = 1 << 7,

    [Offset]
    [Map('D')] SunriseSunset = 1 << 8,
    [Map('N')] Night = 1 << 9,
    [Map('C')] ContinuousTimes = 1 << 10,
    [Map('A')] Notam = 1 << 11
}
