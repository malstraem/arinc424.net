using Arinc.Spec424.Records;

namespace Arinc.Spec424;

public class Data424
{
    public List<Runway> Runways { get; set; } = [];

    public List<Airway> Airways { get; set; } = [];

    public List<Airport> Airports { get; set; } = [];

    public List<AirportApproach> AirportApproaches { get; set; } = [];

    public List<AirportTerminalArrival> AirportTerminalArrivals { get; set; } = [];

    public List<AirportInstrumentDeparture> AirportInstrumentDepartures { get; set; } = [];

    public List<MicrowaveLandingSystem> MicrowaveLandingSystems { get; set; } = [];

    public List<AirportTerminalWaypoint> AirportTerminalWaypoints { get; set; } = [];

    public List<EnrouteWaypoint> EnrouteWaypoints { get; set; } = [];

    public List<CruisingTable> CruisingTables { get; set; } = [];

    public List<HoldingPattern> HoldingPatterns { get; set; } = [];

    public List<NonDirectionalBeacon> NonDirectionalBeacons { get; set; } = [];

    public List<OmnidirectionalStation> OmnidirectionalStations { get; set; } = [];

    public List<FlightPlanning> FlightPlannings { get; set; } = [];

    public List<FlightInfoRegion> FlightInfoRegions { get; set; } = [];

    public List<ControlledAirspace> ControlledAirspaces { get; set; } = [];

    public List<RestrictiveAirspace> RestrictiveAirspaces { get; set; } = [];

    public static Data424 Load(IEnumerable<string> strings) => new Parser424().Parse(strings);
}
