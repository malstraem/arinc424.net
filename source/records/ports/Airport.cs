using Arinc424.Navigation;
using Arinc424.Procedures;
using Arinc424.Waypoints;

namespace Arinc424.Ports;

using Arinc424.Comms;

using Terms;

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See section 4.1.7.1.</remarks>
[Section('P', 'A', subsectionIndex: 13)]
public class Airport : Port
{
    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <value>Hundreds of feet.</value>
    /// <remarks>See section 5.54.</remarks>
    [Field(28, 30), Integer]
    public int LongestRunwayLength { get; set; }

    /// <inheritdoc cref="RunwaySurfaceType"/>
    [Character(32)]
    public RunwaySurfaceType LongestRunwayType { get; set; }

    /// <summary>
    /// Associated gates.
    /// </summary>
    [Many]
    public List<Gate>? Gates { get; set; }

    /// <summary>
    /// Associated runways.
    /// </summary>
    [Many]
    public List<Runway>? Runways { get; set; }

    /// <summary>
    /// Associated GBAS points.
    /// </summary>
    [Many]
    public List<GroundPoint>? GroundPoints { get; set; }

    /// <summary>
    /// Associated SBAS points.
    /// </summary>
    [Many]
    public List<AirportSatellitePoint>? SattelitePoints { get; set; }

    /// <summary>
    /// Associated GLS's.
    /// </summary>
    [Many]
    public List<GlobalLanding>? GlobalLandingSystems { get; set; }

    /// <summary>
    /// Associated MLS's.
    /// </summary>
    [Many]
    public List<MicrowaveLanding>? MicrowaveLandingSystems { get; set; }

    /// <summary>
    /// Associated ILS's.
    /// </summary>
    [Many]
    public List<InstrumentLanding>? InstrumentLandingSystems { get; set; }

    /// <summary>
    /// Associated Localizer Markers.
    /// </summary>
    [Many]
    public List<InstrumentMarker>? Markers { get; set; }

    /// <summary>
    /// Associated Approach Procedures.
    /// </summary>
    [Many]
    public List<AirportApproach>? Approaches { get; set; }

    /// <summary>
    /// Associated STARs.
    /// </summary>
    [Many]
    public List<AirportArrival>? Arrivals { get; set; }

    /// <summary>
    /// Associated SIDs.
    /// </summary>
    [Many]
    public List<AirportDeparture>? Departures { get; set; }

    /// <summary>
    /// Associated NDBs.
    /// </summary>
    [Many]
    public List<TerminalBeacon>? Beacons { get; set; }

    /// <summary>
    /// Associated VHF Navaids.
    /// </summary>
    [Many]
    public List<Omnidirectional>? Omnidirectionals { get; set; }

    /// <summary>
    /// Associated Terminal Waypoints.
    /// </summary>
    [Many]
    public List<AirportTerminalWaypoint>? TerminalWaypoints { get; set; }

    /// <summary>
    /// Associated Communications.
    /// </summary>
    public List<AirportCommunication>? Communications { get; set; }

    /// <summary>
    /// Associated TAAs.
    /// </summary>
    public List<AirportArrivalAltitude>? ArrivalAltitudes { get; set; }

    /// <summary>
    /// Associated MSAs.
    /// </summary>
    public List<AirportMinimumAltitude>? MinimumAltitudes { get; set; }
}
