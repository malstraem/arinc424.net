using Arinc424.Airspace;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Procedures;
using Arinc424.Routing;
using Arinc424.Tables;
using Arinc424.Waypoints;

namespace Arinc424;

/// <summary>
/// Container that represents <c>ARINC 424</c> database.
/// </summary>
public class Data424
{
    public static Data424 Create(IEnumerable<string> strings, Supplement supplement) => new Parser424(supplement).Parse(strings);

    [Section('A', 'S')]
    public List<OffrouteAltitude> OffrouteAltitudes { get; set; } = [];

    #region Navaid
    [Section('D', 'T')]
    public List<Tactical> Tacticals { get; set; } = [];

    [Section('D', 'B')]
    public List<Nondirectional> Nondirectionals { get; set; } = [];

    [Section('D')]
    public List<Omnidirectional> Omnidirectionals { get; set; } = [];
    #endregion

    #region Enroute
    [Section('E', 'R')]
    public List<Airway> Airways { get; set; } = [];

    [Section('E', 'A')]
    public List<Waypoint> EnrouteWaypoints { get; set; } = [];

    [Section('E', 'M')]
    public List<AirwayMarker> AirwayMarkers { get; set; } = [];

    [Section('E', 'P')]
    public List<HoldingPattern> HoldingPatterns { get; set; } = [];

    [Section('E', 'T')]
    public List<PreferredRoute> PreferredRoutes { get; set; } = [];

    [Section('E', 'S')]
    public List<SpecialActivityArea> SpecialActivityAreas { get; set; } = [];

    [Section('E', 'V')]
    public List<AirwayCommunication> AirwayCommunications { get; set; } = [];
    #endregion

    #region Heliport
    [Section('H', 'A')]
    public List<Heliport> Heliports { get; set; } = [];

    [Section('H', 'E')]
    public List<Arrival> HeliportArrivals { get; set; } = [];

    [Section('H', 'F')]
    public List<Approach> HeliportApproaches { get; set; } = [];

    [Section('H', 'D')]
    public List<Departure> HeliportDepartures { get; set; } = [];

    [Section('H', 'V')]
    public List<PortCommunication> HeliportCommunications { get; set; } = [];

    [Section('H', 'K')]
    public List<ArrivalAltitude> HeliportArrivalAltitudes { get; set; } = [];

    [Section('H', 'S')]
    public List<MinimumAltitude> HeliportMinimumAltitudes { get; set; } = [];

    [Section('H', 'P')]
    public List<SatellitePoint> HelicopterSatellitePoints { get; set; } = [];
    #endregion

    #region Airport
    [Section('P', 'B')]
    public List<Gate> Gates { get; set; } = [];

    [Section('P', 'G')]
    public List<Runway> Runways { get; set; } = [];

    [Section('P', 'A')]
    public List<Airport> Airports { get; set; } = [];

    [Section('P', 'R')]
    public List<FlightPlan> FlightPlans { get; set; } = [];

    [Section('P', 'Q')]
    public List<PathPoint> GroundPathPoints { get; set; } = [];

    [Section('P', 'N')]
    public List<TerminalBeacon> TerminalBeacons { get; set; } = [];

    [Section('P', 'E')]
    public List<Arrival> AirportArrivals { get; set; } = [];

    [Section('P', 'F')]
    public List<Approach> AirportApproaches { get; set; } = [];

    [Section('P', 'D')]
    public List<Departure> AirportDepartures { get; set; } = [];

    [Section('P', 'V')]
    public List<PortCommunication> AirportCommunications { get; set; } = [];

    [Section('P', 'P')]
    public List<SatellitePoint> AirportSatellitePoints { get; set; } = [];

    [Section('P', 'K')]
    public List<ArrivalAltitude> AirportArrivalAltitudes { get; set; } = [];

    [Section('P', 'S')]
    public List<MinimumAltitude> AirportMinimumAltitudes { get; set; } = [];

    [Section('P', 'C')]
    public List<TerminalWaypoint> AirportTerminalWaypoints { get; set; } = [];

    [Section('P', 'T')]
    public List<GlobalLanding> GlobalLandings { get; set; } = [];

    [Section('P', 'L')]
    public List<MicrowaveLanding> MicrowaveLandings { get; set; } = [];

    [Section('P', 'I')]
    public List<InstrumentLanding> InstrumentLandings { get; set; } = [];

    [Section('P', 'M')]
    public List<InstrumentMarker> InstrumentMarkers { get; set; } = [];
    #endregion

    #region Company Routes
    [Section('R', 'A')]
    public List<Alternate> Alternates { get; set; } = [];

    [Section('R')]
    public List<CompanyRoute> CompanyRoutes { get; set; } = [];

    [Section('R', 'H')]
    public List<HelicopterCompanyRoute> HelicopterCompanyRoutes { get; set; } = [];
    #endregion

    #region Tables
    [Section('T', 'C')]
    public List<CruiseTable> CruisingTables { get; set; } = [];

    [Section('T', 'V')]
    public List<CommunicationType> CommunicationTypes { get; set; } = [];

    [Section('T', 'G')]
    public List<GeographicalReference> GeographicalReferences { get; set; } = [];
    #endregion

    #region Airspace
    [Section('U', 'F')]
    public List<FlightRegion> FlightRegions { get; set; } = [];

    [Section('U', 'C')]
    public List<ControlledSpace> ControlledSpaces { get; set; } = [];

    [Section('U', 'R')]
    public List<RestrictiveSpace> RestrictiveSpaces { get; set; } = [];
    #endregion
}
