using System.Collections.Frozen;
using System.Reflection;

using Arinc424;
using Arinc424.Airspace;
using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Procedures;
using Arinc424.Routing;
using Arinc424.Tables;
using Arinc424.Waypoints;

#region Mappping (see specification Table 5-1)
[assembly:
Record<OffrouteAltitude>,

#region Navaid
Record<Tactical>,
Record<Nondirectional>,
Record<Omnidirectional>,
#endregion

#region Enroute
Record<Waypoint>,
Record<AirwayMarker>,
Record<PreferredRoute>,
Record<HoldingPattern>,
Record<SpecialActivityArea>,

Sequence<Airway, AirwayPoint>,
Sequence<AirwayCommunication, AirwayTransmitter>,
#endregion

#region Airport and Heliport
Record<Gate>,
Record<Runway>,
Record<Airport>,
Record<FlightPlan>,
Record<SatellitePoint>,
Record<GroundPathPoint>,
Record<ArrivalAltitude>,
Record<MinimumAltitude>,
Record<TerminalWaypoint>,

Record<TerminalBeacon>,

Record<GlobalLanding>,
Record<MicrowaveLanding>,
Record<InstrumentLanding>,

Record<InstrumentMarker>,

Sequence<PortCommunication, PortTransmitter>,

Sequence<ArrivalSequence, ArrivalPoint>,
Sequence<ApproachSequence, ApproachPoint>,
Sequence<DepartureSequence, DeparturePoint>,

Record<Heliport>,
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
Sequence<RegionVolume, RegionPoint>,
Sequence<ControlledVolume, BoundaryPoint>,
Sequence<RestrictiveVolume, BoundaryPoint>,
#endregion
]
#endregion

namespace Arinc424;

internal class Meta424
{
    [Obsolete("todo: supplement versioning (v18 - v23)")]
    internal Meta424(Supplement supplement)
    {
        var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes<InfoAttribute>();

        Info = attributes.SelectMany(x => x.GetInfo(supplement)).ToArray();

        Dictionary<Section, Type> types = [];
        Dictionary<Type, RecordInfo> typeInfo = [];

        foreach (var info in Info)
        {
            types.Add(info.Section, info.Type);

            // types with multiple sections will be stored once
            _ = typeInfo.TryAdd(info.Type, info);
        }
        Types = types.ToFrozenDictionary();
        TypeInfo = typeInfo.ToFrozenDictionary();
    }

    internal FrozenDictionary<Section, Type> Types { get; }

    internal FrozenDictionary<Type, RecordInfo> TypeInfo { get; }

    internal RecordInfo[] Info { get; }
}
