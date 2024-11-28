using System.Collections.Frozen;
using System.Reflection;

using Arinc424;
using Arinc424.Airspace;
using Arinc424.Building;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ground;
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
Record<SpecialArea>,

Record<Airway>,
Record<AirwayCommunication>,
#endregion

#region Airport and Heliport
Record<Gate>,
Record<Runway>,
Record<Airport>,
Record<FlightPlan>,
Record<SatellitePoint>,
Record<GroundPoint>,
Record<ArrivalAltitude>,
Record<MinimumAltitude>,
Record<TerminalWaypoint>,

Record<TerminalBeacon>,

Record<GlobalLanding>,
Record<MicrowaveLanding>,
Record<InstrumentLanding>,

Record<InstrumentMarker>,

Record<PortCommunication>,

Record<Arrival>,
Record<Approach>,
Record<Departure>,

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

Record<CruiseTable>,
#endregion

#region Airspace
Record<FlightRegion>,
Record<ControlledSpace>,
Record<RestrictiveSpace>,
#endregion
]
#endregion

namespace Arinc424;

/// <summary>
/// Metadata that defines how entities should be created.
/// </summary>
public class Meta424
{
    /// <summary>
    /// Creates metadata using target <paramref name="supplement"/>.
    /// </summary>
    /// <returns>Runtime compiled metadata.</returns>
    public static Meta424 Create(Supplement supplement)
    {
        List<SectionAttribute> sections = [];
        Dictionary<Section, Type> types = [];
        Dictionary<Type, RecordInfo> typeInfo = [];
        Dictionary<Section, RecordInfo> info = [];

        var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes<RecordAttribute>();

        foreach (var attribute in attributes.Select(x => x.GetInfo(supplement)))
        {
            foreach (var section in attribute.Sections)
            {
                info.Add(section.Value, attribute);
                types.Add(section.Value, attribute.Composition.Top);
                sections.Add(section);
            }
            // types with multiple sections will be stored once
            _ = typeInfo.TryAdd(attribute.Composition.Top, attribute);
        }
        return new Meta424()
        {
            Info = info.ToFrozenDictionary(),
            Types = types.ToFrozenDictionary(),
            TypeInfo = typeInfo.ToFrozenDictionary(),
            Sections = [.. sections]
        };
    }
#pragma warning disable CS8618
    internal SectionAttribute[] Sections { get; init; }

    internal FrozenDictionary<Section, Type> Types { get; init; }

    internal FrozenDictionary<Section, RecordInfo> Info { get; init; }

    internal FrozenDictionary<Type, RecordInfo> TypeInfo { get; init; }
#pragma warning restore CS8618
}
