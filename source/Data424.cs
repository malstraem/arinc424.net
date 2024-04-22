using Arinc424.Airspace;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Procedures;
using Arinc424.Routing;
using Arinc424.Tables;
using Arinc424.Waypoints;

namespace Arinc424;

/// <summary>
/// Container that represents<c>ARINC 424</c> database.
/// </summary>
public class Data424
{
    public List<Gate> Gates { get; set; } = [];

    public List<Runway> Runways { get; set; } = [];

    public List<Airport> Airports { get; set; } = [];

    public List<AirportBeacon> AirportBeacons { get; set; } = [];

    public List<AirportArrival> AirportArrivals { get; set; } = [];

    public List<AirportApproach> AirportApproaches { get; set; } = [];

    public List<AirportDeparture> AirportDepartures { get; set; } = [];

    public List<AirportTerminalWaypoint> AirportTerminalWaypoints { get; set; } = [];

    public List<GlobalLandingSystem> GlobalLandingSystems { get; set; } = [];

    public List<MicrowaveLandingSystem> MicrowaveLandingSystems { get; set; } = [];

    public List<InstrumentLandingSystem> InstrumentLandingSystems { get; set; } = [];

    public List<InstrumentLandingMarker> InstrumentLandingMarkers { get; set; } = [];

    public List<NondirectionalBeacon> NondirectionalBeacons { get; set; } = [];

    public List<OmnidirectionalStation> OmnidirectionalStations { get; set; } = [];

    public List<Airway> Airways { get; set; } = [];

    public List<HoldingPattern> HoldingPatterns { get; set; } = [];

    public List<EnrouteWaypoint> EnrouteWaypoints { get; set; } = [];

    public List<SpecialActivityArea> SpecialActivityAreas { get; set; } = [];

    public List<FlightPlanning> FlightPlannings { get; set; } = [];

    public List<FlightInfoRegion> FlightInfoRegions { get; set; } = [];

    public List<ControlledAirspace> ControlledAirspaces { get; set; } = [];

    public List<RestrictiveAirspace> RestrictiveAirspaces { get; set; } = [];

    public List<CruiseTable> CruisingTables { get; set; } = [];

    public static Data424 Load(IEnumerable<string> strings) => new Parser424().Parse(strings);
}
