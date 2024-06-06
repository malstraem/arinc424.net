namespace Arinc424.Ports.Terms;

[Decode<SectorConverter, Sector>]
public class Sector(Sectorization sectorization, int altitude, int radius)
{
    /// <summary>
    /// <c>Sector Bearing (SEC BRG)</c> field.
    /// </summary>
    /// <remarks>See section 5.146.</remarks>
    public Sectorization Sectorization { get; set; } = sectorization;

    /// <summary>
    /// <c>Sector Altitude (SEC ALT)</c> field.
    /// </summary>
    /// <value>Hundreds of feet.</value>
    /// <remarks>See section 5.147.</remarks>
    public int Altitude { get; set; } = altitude;

    /// <summary>
    /// <c>Radius Limit </c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.145.</remarks>
    public int Radius { get; set; } = radius;
}
