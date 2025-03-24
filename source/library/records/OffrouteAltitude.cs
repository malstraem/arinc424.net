namespace Arinc424;

/**<summary>
<c>Grid MORA</c> primary record.
</summary>
<remarks>See section 4.1.19.1.</remarks>*/
[Section('A', 'S')]
public class OffrouteAltitude : Record424
{
    [Field(14, 20)]
    [Decode<StartingCoordinatesConverter, Coordinates>]
    public Coordinates Coordinates { get; set; }

    [Field(31, 33), Count(30)]
    [Decode<MinimumAltitudeConverter, Altitude>]
    public Altitude[] Altitudes { get; set; }
}
