using System.Collections.Frozen;
using System.Reflection;

using Arinc424;
using Arinc424.Airspace;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Procedures;
using Arinc424.Routing;
using Arinc424.Tables;
using Arinc424.Waypoints;

#region Mappping
// see specification Table 5-1
[assembly:
Record<OffrouteAltitude>,

#region Navaid
Record<Tactical>,
Record<Nondirectional>,
Record<Omnidirectional>,
#endregion

#region Enroute
Record<AirwayMarker>,
Record<HoldingPattern>,
Record<EnrouteWaypoint>,
Record<SpecialActivityArea>,

Sequence<Airway, AirwayPoint>,
Sequence<AirwayCommunications, AirwayTransmitter>,
#endregion

#region Heliport
Record<Heliport>,
Record<HeliportCommunications>,
Record<HeliportArrivalAltitudes>,
Record<HeliportMinimumAltitudes>,
Record<HeliportTerminalWaypoint>,
Record<HelicopterSatellitePoint>,

Sequence<HeliportArrival, ArrivalPoint>,
Sequence<HeliportApproach, ApproachPoint>,
Sequence<HeliportDeparture, DeparturePoint>,
#endregion

#region Airport
Record<Gate>,
Record<Runway>,
Record<Airport>,
Record<GroundPoint>,
Record<FlightPlanning>,
Record<AirportSatellitePoint>,
Record<AirportArrivalAltitudes>,
Record<AirportMinimumAltitudes>,
Record<AirportTerminalWaypoint>,

Record<AirportBeacon>,
Record<GlobalLandingSystem>,
Record<MicrowaveLandingSystem>,
Record<InstrumentLandingSystem>,
Record<InstrumentLandingMarker>,

Sequence<AirportArrivalSequence, ArrivalPoint>,
Sequence<AirportApproachSequence, ApproachPoint>,
Sequence<AirportDepartureSequence, DeparturePoint>,

Sequence<AirportCommunications, PortTransmitter>,
#endregion

#region Company Routes
Record<Alternate>,
#endregion

#region Tables
Record<CommunicationType>,
Record<GeographicalReference>,

Sequence<CruiseTable, CruiseRow>,
#endregion

#region Airspace
Sequence<FlightInfoRegion, FlightRegionPoint>,
Sequence<ControlledAirspace, BoundaryPoint>,
Sequence<RestrictiveAirspace, BoundaryPoint>,
#endregion 
]
#endregion

namespace Arinc424;

internal class Meta424
{
    [Obsolete("todo: supplement versioning (v18 - v23)")]
    internal Meta424()
    {
        Builds = Assembly.GetExecutingAssembly().GetCustomAttributes<BuildAttribute>();

        Dictionary<(char, char), Type> types = [];
        Dictionary<Type, BuildAttribute> info = [];
        Dictionary<Type, LinksAttribute> links = [];

        foreach (var attribute in Builds)
        {
            info.Add(attribute.Type, attribute);
            links.Add(attribute.Type, attribute);
            types.Add(attribute.Section, attribute.Type);
        }
        links.Add(typeof(AirportArrival), new LinksAttribute(typeof(AirportArrival)));
        links.Add(typeof(AirportApproach), new LinksAttribute(typeof(AirportApproach)));
        links.Add(typeof(AirportDeparture), new LinksAttribute(typeof(AirportDeparture)));

        Info = info.ToFrozenDictionary();
        Types = types.ToFrozenDictionary();
        Links = links.ToFrozenDictionary();
    }

    internal IEnumerable<LinksAttribute> GetWithPrimaryKey() => Links.Select(x => x.Value).Where(x => x.PrimaryKey is not null);

    internal IEnumerable<LinksAttribute> GetWithLinks() => Links.Select(x => x.Value).Where(x => x.Links is not null);

    internal IEnumerable<BuildAttribute> Builds { get; } = Assembly.GetExecutingAssembly().GetCustomAttributes<BuildAttribute>();

    internal FrozenDictionary<(char, char), Type> Types { get; }

    internal FrozenDictionary<Type, BuildAttribute> Info { get; }

    internal FrozenDictionary<Type, LinksAttribute> Links { get; }
}
