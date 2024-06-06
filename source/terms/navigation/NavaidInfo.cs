namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fourth character of <c>NAVAID Class (CLASS)</c> field.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<NavaidInfoConverter, NavaidInfo>]
public enum NavaidInfo : byte
{
    Unknown,
    [Map('D')] Biased,
    [Map('A')] AutomaticBroadcast,
    [Map('B')] ScheduledBroadcast,
    [Map('W')] NoVoice,
    [Map] Voice,
}
