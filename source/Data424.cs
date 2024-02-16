using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;

[assembly: OneToMany<Airport, Runway>]
[assembly: OneToMany<Airport, AirportApproach>]
[assembly: OneToMany<Airport, NonDirectionalBeacon>]
[assembly: OneToMany<Airport, OmnidirectionalStation>]
[assembly: OneToMany<Airport, AirportTerminalArrival>]
[assembly: OneToMany<Airport, AirportInstrumentDeparture>]

namespace Arinc.Spec424;

public class Data424
{
    public IReadOnlyCollection<Runway> Runways { get; set; }

    public IReadOnlyCollection<Airway> Airways { get; set; }

    public IReadOnlyCollection<Airport> Airports { get; set; }

    public IReadOnlyCollection<Waypoint> Waypoints { get; set; }

    public IReadOnlyCollection<CruisingTable> CruisingTables { get; set; }

    public IReadOnlyCollection<HoldingPattern> HoldingPatterns { get; set; }

    public IReadOnlyCollection<AirportApproach> AirportApproaches { get; set; }

    public IReadOnlyCollection<NonDirectionalBeacon> NonDirectionalBeacons { get; set; }

    public IReadOnlyCollection<OmnidirectionalStation> VeryHighFrequencyAids { get; set; }

    public IReadOnlyCollection<MicrowaveLandingSystem> MicrowaveLandingSystems { get; set; }

    public IReadOnlyCollection<AirportTerminalArrival> StandardTerminalArrivals { get; set; }

    public IReadOnlyCollection<AirportInstrumentDeparture> StandardInstrumentDepartures { get; set; }

    public IReadOnlyCollection<FlightPlanning> FlightPlannings { get; set; }

    public IReadOnlyCollection<FlightInfoRegion> FlightInfoRegions { get; set; }

    public IReadOnlyCollection<ControlledAirspace> ControlledAirspaces { get; set; }

    public IReadOnlyCollection<RestrictiveAirspace> RestrictiveAirspaces { get; set; }

    public static Data424 Load(IEnumerable<string> strings) => new Parser424().Parse(strings);
}
