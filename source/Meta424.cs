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
Record<CompanyRoute>,
Record<HelicopterCompanyRoute>,
#endregion

#region Tables
Record<CommunicationType>,
Record<GeographicalReference>,

Sequence<CruiseTable, CruiseRow>,
#endregion

#region Airspace
Sequence<FlightInfoRegion, RegionPoint>,
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
        Dictionary<(char, char), Type> types = [];
        Dictionary<Type, InfoAttribute> typeInfo = [];

        foreach (var info in Info)
        {
            types.Add(info.Section, info.Type);
            typeInfo.Add(info.Type, info);
        }
        Types = types.ToFrozenDictionary();
        TypeInfo = typeInfo.ToFrozenDictionary();
    }

    internal FrozenDictionary<(char, char), Type> Types { get; }

    internal FrozenDictionary<Type, InfoAttribute> TypeInfo { get; }

    internal IEnumerable<InfoAttribute> Info { get; } = Assembly.GetExecutingAssembly().GetCustomAttributes<InfoAttribute>();
}
