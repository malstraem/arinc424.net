using System.Collections.Frozen;
using System.Reflection;

using Arinc424.Airspace;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Procedures;
using Arinc424.Routing;
using Arinc424.Tables;
using Arinc424.Waypoints;

[assembly:
Record<Gate>,
Record<Runway>,
Record<Airport>,
Record<FlightPlanning>,
Record<GroundPoint>,
Record<AirportArrivalAltitudes>,
Record<AirportMinimumAltitudes>,
Record<AirportTerminalWaypoint>,
Record<AirportSatellitePoint>,
Sequence<AirportCommunications, PortTransmitter>,

Record<Heliport>,
Record<HeliportCommunications>,
Record<HeliportArrivalAltitudes>,
Record<HeliportMinimumAltitudes>,
Record<HeliportTerminalWaypoint>,

Sequence<AirportArrival, ArrivalPoint>,
Sequence<AirportApproach, ApproachPoint>,
Sequence<AirportDeparture, DeparturePoint>,
Sequence<HeliportArrival, ArrivalPoint>,
Sequence<HeliportApproach, ApproachPoint>,
Sequence<HeliportDeparture, DeparturePoint>,

Record<AirportBeacon>,
Record<TacticalSystem>,
Record<Nondirectional>,
Record<Omnidirectional>,

Record<GlobalLandingSystem>,
Record<MicrowaveLandingSystem>,
Record<InstrumentLandingSystem>,
Record<InstrumentLandingMarker>,

Record<Alternate>,
Record<AirwayMarker>,
Record<HoldingPattern>,
Record<EnrouteWaypoint>,
Record<SpecialActivityArea>,
Sequence<Airway, AirwayPoint>,
Sequence<AirwayCommunications, AirwayTransmitter>,

Sequence<FlightInfoRegion, FlightRegionPoint>,
Sequence<ControlledAirspace, BoundaryPoint>,
Sequence<RestrictiveAirspace, BoundaryPoint>,

Sequence<CruiseTable, CruiseRow>]

namespace Arinc424;

internal class Meta424
{
    internal Meta424()
    {
        var assembly = Assembly.GetExecutingAssembly();

        Records = assembly.GetCustomAttributes<RecordAttribute>();
        Sequences = assembly.GetCustomAttributes<SequenceAttribute>();

        Dictionary<Type, InfoAttribute> info = [];
        Dictionary<(char, char), Type> types = [];

        foreach (var attribute in Records.Cast<InfoAttribute>().Concat(Sequences))
        {
            info.Add(attribute.Type, attribute);
            types.Add((attribute.Section.SectionChar, attribute.Section.SubsectionChar), attribute.Type);
        }
        Info = info.ToFrozenDictionary();
        Types = types.ToFrozenDictionary();
    }

    internal IEnumerable<InfoAttribute> GetWithPrimaryKey() => Info.Select(x => x.Value).Where(x => x.PrimaryKey is not null);

    internal IEnumerable<InfoAttribute> GetWithLinks() => Info.Select(x => x.Value).Where(x => x.Links is not null);

    internal IEnumerable<RecordAttribute> Records { get; }

    internal IEnumerable<SequenceAttribute> Sequences { get; }

    internal FrozenDictionary<Type, InfoAttribute> Info { get; }

    internal FrozenDictionary<(char, char), Type> Types { get; }
}
