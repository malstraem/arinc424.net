namespace Arinc424.Navigation.Terms;

/// <summary>
/// Fifth character of <c>NAVAID Class (CLASS)</c> field, specific to <see cref="Omnidirectional"/>.
/// </summary>
/// <remarks>See section 5.35.</remarks>
[Char, Transform<OmnidirectCollocationConverter, OmnidirectCollocation>]
[Description("NAVAID Class (CLASS) - Collocation")]
public enum OmnidirectCollocation : byte
{
    Unknown,
    /// <summary>
    /// The latitude/longitude position of the VOR or Localizer portion
    /// and the DME or TACAN portion of a VORDME, VORTAC, ILSDME or ILSTACAN are identical.
    /// </summary>
    [Map] Collocated,
    /// <summary>
    /// The latitude/longitude position of the VOR or Localizer portion
    /// and the DME or TACAN portion of a VORDME, VORTAC, ILSDME or ILSTACAN are not identical.
    /// </summary>
    [Map('N')] Non
}
