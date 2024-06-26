namespace Arinc424.Ports;

/// <summary>
/// <c>Helicopter Operations SBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.2.8.1.</remarks>
[Section('H', 'P', subsectionIndex: 13)]
public class HelicopterSatellitePoint : SatellitePoint
{
    [Field(7, 12)]
    [Obsolete("airport or heliport, need to be post processed")]
    public string PortIdentifier { get; set; }

    [Field(14, 19), Obsolete("todo")]
    public string ApproachIdentifier { get; set; }

    [Field(20, 24), Obsolete("todo")]
    public string AsRunway { get; set; }
}
