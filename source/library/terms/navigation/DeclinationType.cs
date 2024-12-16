namespace Arinc424.Navigation.Terms;

/// <summary>
/// First character of <c>Station Declination (STN DEC)</c>.
/// </summary>
/// <remarks>See section 5.66.</remarks>
[Char, Transform<DeclinationTypeConverter, DeclinationType>]
public enum DeclinationType : byte
{
    Unknown,
    /// <summary>
    /// Declination is East of True North.
    /// </summary>
    [Map('E')] East,
    /// <summary>
    /// Declination is West of True North.
    /// </summary>
    [Map('W')] West,
    /// <summary>
    /// Station is oriented to True North in an area in which the local variation is not zero.
    /// </summary>
    [Map('T')] True,
    /// <summary>
    /// Station is oriented to Grid North.
    /// </summary>
    [Map('G')] Grid
}
