namespace Arinc424;

/// <summary>
/// An entity that has two character ICAO code.
/// </summary>
public interface IIcao
{
    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    string IcaoCode { get; }
}
