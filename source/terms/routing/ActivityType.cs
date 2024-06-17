namespace Arinc424.Routing.Terms;

/// <summary>
/// <c>Activity Type</c> character.
/// </summary>
/// <remarks>See section 5.278.</remarks>
[Char, Transform<ActivityTypeConverter, ActivityType>]
public enum ActivityType : byte
{
    Unknown,
    [Map('P')] Parachute,
    [Map('G')] Glider,
    [Map('H')] HangGlider,
    [Map('U')] Ultralight
}
