namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fourth character of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Nondirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<NondirectInfoConverter, NondirectInfo>]
[Description("NAVAID Class (CLASS) - Additional Information")]
public enum NondirectInfo : byte
{
    Unknown,
    /// <summary>
    /// The frequency is used for the continuous broadcast (AWOS, ASOS, TWEB, AWIB, AWIS).
    /// </summary>
    [Map('A')] AutomaticBroadcast,
    /// <summary>
    /// The frequency is used for the scheduled, non-continuous broadcast (VOLMET).
    /// </summary>
    [Map('B')] ScheduledBroadcast,
    /// <summary>
    /// The frequency is not used to support two-way communication between a ground station and aircraft.
    /// </summary>
    [Map('W')] NoVoice,
    /// <summary>
    /// The frequency is used to support two-way communication between a ground station and aircraft.
    /// </summary>
    [Map] Voice
}
