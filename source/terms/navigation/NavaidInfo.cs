namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fourth character of <c>NAVAID Class (CLASS)</c> field.
/// </summary>
/// <remarks>See section 5.35.</remarks>
public enum NavaidInfo : byte
{
    Unknown,
    Biased,
    AutomaticBroadcast,
    ScheduledBroadcast,
    NoVoice,
    Voice,
}
