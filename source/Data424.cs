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
    public static Data424 Create(IEnumerable<string> strings, Supplement supplement = Supplement.Unknown) => new Parser424(supplement).Parse(strings);

    public List<OffrouteAltitude> OffrouteAltitudes { get; set; } = [];

    #region Navaid
    public List<Tactical> Tacticals { get; set; } = [];

    public List<Nondirectional> Nondirectionals { get; set; } = [];

    public List<Omnidirectional> Omnidirectionals { get; set; } = [];
    #endregion

    #region Enroute
    public List<Airway> Airways { get; set; } = [];

    public List<AirwayMarker> AirwayMarkers { get; set; } = [];

    public List<HoldingPattern> HoldingPatterns { get; set; } = [];

    public List<PreferredRoute> PreferredRoutes { get; set; } = [];

    public List<EnrouteWaypoint> EnrouteWaypoints { get; set; } = [];

    public List<SpecialActivityArea> SpecialActivityAreas { get; set; } = [];

    public List<AirwayCommunication> AirwayCommunications { get; set; } = [];
    #endregion

    #region Heliport
    public List<Heliport> Heliports { get; set; } = [];

    public List<HeliportArrival> HeliportArrivals { get; set; } = [];

    public List<HeliportApproach> HeliportApproaches { get; set; } = [];

    public List<HeliportDeparture> HeliportDepartures { get; set; } = [];

    public List<HeliportCommunication> HeliportCommunications { get; set; } = [];

    public List<HeliportArrivalAltitude> HeliportArrivalAltitudes { get; set; } = [];

    public List<HeliportMinimumAltitude> HeliportMinimumAltitudes { get; set; } = [];

    public List<HelicopterSatellitePoint> HelicopterSatellitePoints { get; set; } = [];
    #endregion

    #region Airport
    public List<Gate> Gates { get; set; } = [];

    public List<Runway> Runways { get; set; } = [];

    public List<Airport> Airports { get; set; } = [];

    public List<FlightPlan> FlightPlans { get; set; } = [];

    public List<GroundPoint> GroundPoints { get; set; } = [];

    public List<TerminalBeacon> AirportBeacons { get; set; } = [];

    public List<AirportArrival> AirportArrivals { get; set; } = [];

    public List<AirportApproach> AirportApproaches { get; set; } = [];

    public List<AirportDeparture> AirportDepartures { get; set; } = [];

    public List<AirportCommunication> AirportCommunications { get; set; } = [];

    public List<AirportSatellitePoint> AirportSatellitePoints { get; set; } = [];

    public List<AirportArrivalAltitude> AirportArrivalAltitudes { get; set; } = [];

    public List<AirportMinimumAltitude> AirportMinimumAltitudes { get; set; } = [];

    public List<AirportTerminalWaypoint> AirportTerminalWaypoints { get; set; } = [];

    public List<GlobalLanding> GlobalLandings { get; set; } = [];

    public List<MicrowaveLanding> MicrowaveLandings { get; set; } = [];

    public List<InstrumentLanding> InstrumentLandings { get; set; } = [];

    public List<InstrumentMarker> InstrumentMarkers { get; set; } = [];
    #endregion

    #region Company Routes
    public List<Alternate> Alternates { get; set; } = [];

    public List<CompanyRoute> CompanyRoutes { get; set; } = [];

    public List<HelicopterCompanyRoute> HelicopterCompanyRoutes { get; set; } = [];
    #endregion

    #region Tables
    public List<CruiseTable> CruisingTables { get; set; } = [];

    public List<CommunicationType> CommunicationTypes { get; set; } = [];

    public List<GeographicalReference> GeographicalReferences { get; set; } = [];
    #endregion

    #region Airspace
    public List<FlightRegion> FlightRegions { get; set; } = [];

    public List<ControlledSpace> ControlledSpaces { get; set; } = [];

    public List<RestrictiveSpace> RestrictiveSpaces { get; set; } = [];
    #endregion
}
