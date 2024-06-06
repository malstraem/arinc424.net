namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fifth character of <c>NAVAID Class (CLASS)</c> field.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Transform<NavaidCollocationConverter, NavaidCollocation>]
public enum NavaidCollocation : byte
{
    Unknown,
    Collocated,
    NonCollocated,
    BeatFrequencyOscillator
}
