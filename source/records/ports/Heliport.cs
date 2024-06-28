using Arinc424.Comms;
using Arinc424.Procedures;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport</c> primary record.
/// </summary>
/// <remarks>See section 4.2.1.1.</remarks>
[Section('H', 'A', subsectionIndex: 13)]
public class Heliport : Port
{
    [Obsolete("need to be post processed")]
    [Field(17, 21)]
    public string PadIdentifier { get; set; }

    /// <summary>
    /// Associated SBAS points.
    /// </summary>
    [Many]
    public List<HelicopterSatellitePoint>? SattelitePoints { get; set; }

    /// <summary>
    /// Associated Approach Procedures.
    /// </summary>
    [Many]
    public List<HeliportApproach>? Approaches { get; set; }

    /// <summary>
    /// Associated STARs.
    /// </summary>
    [Many]
    public List<HeliportArrival>? Arrivals { get; set; }

    /// <summary>
    /// Associated SIDs.
    /// </summary>
    [Many]
    public List<HeliportDeparture>? Departures { get; set; }

    /// <summary>
    /// Associated Terminal Waypoints.
    /// </summary>
    [Many]
    public List<HeliportTerminalWaypoint>? TerminalWaypoints { get; set; }

    /// <summary>
    /// Associated Communications
    /// </summary>
    public List<HeliportCommunication>? Communications { get; set; }

    /// <summary>
    /// Associated TAAs.
    /// </summary>
    public List<HeliportArrivalAltitude>? ArrivalAltitudes { get; set; }

    /// <summary>
    /// Associated MSAs.
    /// </summary>
    public List<HeliportMinimumAltitude>? MinimumAltitudes { get; set; }
}
