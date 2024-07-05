using System.Collections.Frozen;
using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424;
using Arinc424.Airspace;
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
Record<AirwayMarker>,
Record<PreferredRoute>,
Record<HoldingPattern>,
Record<EnrouteWaypoint>,
Record<SpecialActivityArea>,

Sequence<Airway, AirwayPoint>,
Sequence<AirwayCommunication, AirwayTransmitter>,
#endregion

#region Heliport
Record<Heliport>,
Record<HeliportArrivalAltitude>,
Record<HeliportMinimumAltitude>,
Record<HeliportTerminalWaypoint>,
Record<HelicopterSatellitePoint>,

Sequence<HeliportCommunication, PortTransmitter>,

Sequence<HeliportArrivalSequence, ArrivalPoint>,
Sequence<HeliportApproachSequence, ApproachPoint>,
Sequence<HeliportDepartureSequence, DeparturePoint>,
#endregion

#region Airport
Record<Gate>,
Record<Runway>,
Record<Airport>,
Record<FlightPlan>,
Record<GroundPoint>,
Record<AirportSatellitePoint>,
Record<AirportArrivalAltitude>,
Record<AirportMinimumAltitude>,
Record<AirportTerminalWaypoint>,

Record<TerminalBeacon>,
Record<GlobalLandingSystem>,
Record<MicrowaveLandingSystem>,
Record<InstrumentLandingSystem>,
Record<InstrumentLandingMarker>,

Sequence<AirportCommunication, PortTransmitter>,

Sequence<AirportArrivalSequence, ArrivalPoint>,
Sequence<AirportApproachSequence, ApproachPoint>,
Sequence<AirportDepartureSequence, DeparturePoint>,
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
    internal FrozenDictionary<(char, char), Type> types;

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
        this.types = types.ToFrozenDictionary();
        TypeInfo = typeInfo.ToFrozenDictionary();
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetType(char section, char subsection, out Type? type) => types.TryGetValue((section, subsection), out type);

    internal FrozenDictionary<Type, InfoAttribute> TypeInfo { get; }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //internal bool TryGetInfo(Type type, out InfoAttribute? info) => typeInfo.TryGetValue(type, out info);

    internal IEnumerable<InfoAttribute> Info { get; } = Assembly.GetExecutingAssembly().GetCustomAttributes<InfoAttribute>();
}
