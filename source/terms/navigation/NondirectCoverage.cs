namespace Arinc424.Navigation.Terms;

/// <summary>
/// Third character of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Nondirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<NondirectCoverageConverter, NondirectCoverage>]
[Description("NAVAID Class (CLASS) - Coverage")]
public enum NondirectCoverage : byte
{
    Unknown,
    /// <summary>
    /// Generally usable within 75NM of the facility at all altitudes.
    /// </summary>
    [Map('H')] HighPowered,
    /// <summary>
    /// Generally usable within 50NM of the facility at all altitudes.
    /// </summary>
    [Map] Default,
    /// <summary>
    /// Generally usable within 25NM of the facility at all altitude.
    /// </summary>
    [Map('M')] LowPowered,
    /// <summary>
    /// Generally usable within 15NM of the facility at all altitudes.
    /// </summary>
    [Map('L')] Locator
}
