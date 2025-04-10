namespace Arinc424.Ground.Terms;

[Decode<SectorConverter, Sector>]
public class Sector
{
    /// <inheritdoc cref="Arinc424.Sectorization"/>
    public Sectorization Sectorization { get; set; }

    /**<summary>
    <c>Sector Altitude (SEC ALT)</c> field.
    </summary>
    <value>Hundreds of feet.</value>
    <remarks>See section 5.147.</remarks>*/
    public int Altitude { get; set; }

    /**<summary>
    <c>Radius Limit</c> or <c>TAA Sector Radius</c> field.
    </summary>
    <value>Nautical miles.</value>
    <remarks>See section 5.145, 5.274.</remarks>*/
    public int Radius { get; set; }
}
