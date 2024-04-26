using System.Reflection;

using Arinc424.Airspace;
using Arinc424.Attributes;
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
Record<GroundAugmentPoint>,
Record<AirportArrivalAltitudes>,
Record<AirportMinimumAltitudes>,
Record<AirportTerminalWaypoint>,
Record<AirportSatelliteAugmentPoint>,
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
Record<NondirectionalBeacon>,
Record<OmnidirectionalStation>,

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

Sequence<CruiseTable, CruiseTableRow>]

namespace Arinc424;

internal static class Meta424
{
    static Meta424()
    {
        var infos = Records.Cast<InfoAttribute>().Concat(Sequences);

        foreach (var info in infos)
        {
            Infos.Add(info.Type, info);
            Types.Add((info.Section.SectionChar, info.Section.SubsectionChar), info.Type);
        }
    }

    internal static Dictionary<(char, char), Type> Types { get; } = [];

    internal static Dictionary<Type, InfoAttribute> Infos { get; } = [];

    internal static IEnumerable<RecordAttribute> Records { get; } = Assembly.GetExecutingAssembly().GetCustomAttributes<RecordAttribute>();

    internal static IEnumerable<SequenceAttribute> Sequences { get; } = Assembly.GetExecutingAssembly().GetCustomAttributes<SequenceAttribute>();
}
