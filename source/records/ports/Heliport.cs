using Arinc424.Comms;
using Arinc424.Procedures;
using Arinc424.Processing;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport</c> primary record.
/// </summary>
/// <remarks>See section 4.2.1.1.</remarks>
[Section('H', 'A', subsectionIndex: 13)]
[Process<Heliport, Heliport, HelipadConcatenater>]
public class Heliport : Port
{
    /// <summary>
    /// Associated Helipads.
    /// </summary>
    [Many]
    public List<Helipad>? Helipads { get; set; }

    /// <summary>
    /// Associated STARs.
    /// </summary>
    [Many]
    public List<HeliportArrival>? Arrivals { get; set; }

    /// <summary>
    /// Associated Approach Procedures.
    /// </summary>
    [Many]
    public List<HeliportApproach>? Approaches { get; set; }

    /// <summary>
    /// Associated SIDs.
    /// </summary>
    [Many]
    public List<HeliportDeparture>? Departures { get; set; }

    /// <summary>
    /// Associated SBAS points.
    /// </summary>
    [Many]
    public List<HelicopterSatellitePoint>? SattelitePoints { get; set; }

    /// <summary>
    /// Associated Terminal Waypoints.
    /// </summary>
    [Many]
    public List<HeliportTerminalWaypoint>? TerminalWaypoints { get; set; }

    /// <summary>
    /// Associated Communications
    /// </summary>
    [Many]
    public List<PortCommunication>? Communications { get; set; }

    /// <summary>
    /// Associated TAAs.
    /// </summary>
    [Many]
    public List<HeliportArrivalAltitude>? ArrivalAltitudes { get; set; }

    /// <summary>
    /// Associated MSAs.
    /// </summary>
    [Many]
    public List<HeliportMinimumAltitude>? MinimumAltitudes { get; set; }
}
