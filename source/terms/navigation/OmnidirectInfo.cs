namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fourth character of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Omnidirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<OmnidirectInfoConverter, OmnidirectInfo>]
public enum OmnidirectInfo : byte
{
    Unknown,
    /// <summary>
    /// The zero range reading of the DME facility is not at the transmitting antenna site.
    /// </summary>
    [Map('D')] Biased,
    /// <inheritdoc cref="NondirectInfo.AutomaticBroadcast"/>
    [Map('A')] AutomaticBroadcast,
    /// <inheritdoc cref="NondirectInfo.ScheduledBroadcast"/>
    [Map('B')] ScheduledBroadcast,
    /// <inheritdoc cref="NondirectInfo.NoVoice"/>
    [Map('W')] NoVoice,
    /// <inheritdoc cref="NondirectInfo.Voice"/>
    [Map] Voice
}
