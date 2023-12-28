using Arinc.Spec424.Records;

namespace Arinc.Spec424;

public class ArincData424
{
    public required IReadOnlyCollection<Runway> Runways { get; init; }

    public required IReadOnlyCollection<Airway> Airways { get; init; }

    public required IReadOnlyCollection<Airport> Airports { get; init; }

    public required IReadOnlyCollection<Waypoint> Waypoints { get; init; }

    public required IReadOnlyCollection<CruisingTable> CruisingTables { get; init; }

    public required IReadOnlyCollection<HoldingPattern> HoldingPatterns { get; init; }

    public required IReadOnlyCollection<AirportApproach> AirportApproaches { get; init; }

    public required IReadOnlyCollection<NonDirectionalBeacon> NonDirectionalBeacons { get; init; }

    public required IReadOnlyCollection<NavigationalAid> NavigationalAids { get; init; }

    public required IReadOnlyCollection<MicrowaveLandingSystem> MicrowaveLandingSystems { get; init; }

    public required IReadOnlyCollection<StandardTerminalArrival> StandardTerminalArrivals { get; init; }

    public required IReadOnlyCollection<StandardInstrumentDeparture> StandardInstrumentDepartures { get; init; }

    public required IReadOnlyCollection<FlightPlanning> FlightPlannings { get; init; }

    public required IReadOnlyCollection<FlightInfoRegion> FlightInfoRegions { get; init; }

    public required IReadOnlyCollection<ControlledAirspace> ControlledAirspaces { get; init; }

    public required IReadOnlyCollection<RestrictiveAirspace> RestrictiveAirspaces { get; init; }

    public static ArincData424 Load(IEnumerable<string> strings)
    {
        Parser424 parser = new();

        return parser.Parse(strings);
    }
}
