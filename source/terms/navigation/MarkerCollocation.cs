namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fifth character of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="InstrumentLandingMarker"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<MarkerCollocationConverter, MarkerCollocation>]
public enum MarkerCollocation : byte
{
    Unknown,
    /// <inheritdoc cref="NondirectCollocation.BeatFrequencyOscillator"/>
    [Map('B')] BeatFrequencyOscillator,
    /// <summary>
    /// The latitude/longitude position of the Locator and Marker are identical.
    /// </summary>
    [Map('A')] Collocated,
    /// <summary>
    /// The latitude/longitude position of Locator and Marker are not identical.
    /// </summary>
    [Map('N')] Non
}
