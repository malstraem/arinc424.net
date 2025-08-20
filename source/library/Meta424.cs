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
using Arinc424.Linking;

#region Mappping (see specification Table 5-1)
[assembly:
Record<OffrouteAltitude>,

#region Navaid
Record<Tactical>,
Record<Nondirect>,
Record<Omnidirect>,
#endregion

#region Enroute
Record<Waypoint>,
Record<SpecialArea>,
Record<AirwayMarker>,
Record<HoldingPattern>,
Record<PreferredRoute>,

Record<Airway>,
Record<AirwayCommunication>,
#endregion

#region Airport and Heliport
Record<Pad>,
Record<Gate>,
Record<Airport>,
Record<Heliport>,
Record<Threshold>,
Record<FlightPlan>,
Record<GroundPoint>,
Record<SatellitePoint>,
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
#endregion

#region Company Routes
Record<Alternate>,
Record<CompanyRoute>,
Record<HelicopterCompanyRoute>,
#endregion

#region Tables
Record<CruiseTable>,
Record<CommunicationType>,
Record<GeographicalReference>,
#endregion

#region Airspace
Record<FlightRegion>,
Record<ControlledSpace>,
Record<RestrictiveSpace>,
#endregion
]
#endregion

namespace Arinc424;

/**<summary>
Metadata that defines how entities should be created.
</summary>*/
public class Meta424
{
#pragma warning disable CS8618
    private Meta424() { }
#pragma warning restore CS8618
    /**<summary>
    Finds info for all base classes in strong type relations.
    </summary>*/
    private static void FillBaseInfo
    (
        Supplement supplement,
        Dictionary<Type, KeyInfo> keyInfo,
        Dictionary<Type, BaseInfo> typeInfo
    )
    {
        HashSet<Type> linkedTypes = [];

        foreach (var (_, recordInfo) in typeInfo)
        {
            if (recordInfo.Relations is null)
                continue;

            foreach (var link in recordInfo.Relations.SelectMany(x => x.Links))
            {
                if (!link.IsPolymorph)
                    _ = linkedTypes.Add(link.Type);
            }
        }

        Dictionary<Type, List<BaseInfo>> inheritance = [];

        foreach (var linked in linkedTypes)
        {
            foreach (var (type, info) in typeInfo)
            {
                if (type.IsSubclassOf(linked))
                {
                    if (!inheritance.TryGetValue(linked, out var inherited))
                        inheritance[linked] = inherited = [];

                    inherited.Add(info);
                }
            }
        }

        foreach (var (type, inherited) in inheritance)
        {
            List<SectionAttribute> sections = [];

            if (type.TryKeyInfo(supplement, out var key))
                keyInfo[type] = key.Value;

            foreach (var info in inherited)
                sections.AddRange(info.Sections);

            var composition = type.Decompose(supplement, out var relations, out _);

            if (relations is null)
                throw new InvalidOperationException();
            /* never been thrown if integrity tests pass */

            typeInfo[type] = new BaseInfo(composition, [.. sections], relations);
        }
    }

    /**<summary>
    Creates metadata using target <paramref name="supplement"/>.
    </summary>
    <returns>Runtime compiled metadata.</returns>*/
    public static Meta424 Create(Supplement supplement)
    {
        List<SectionAttribute> sections = [];

        Dictionary<Type, KeyInfo> keyInfo = [];
        Dictionary<Type, BaseInfo> linked = [];

        Dictionary<Section, Type> types = [];
        Dictionary<Section, RecordInfo> info = [];

        var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes<RecordAttribute>();

        foreach (var attribute in attributes)
        {
            var recordInfo = attribute.GetInfo(supplement);

            foreach (var section in recordInfo.Sections)
            {
                info.Add(section.Value, recordInfo);
                types.Add(section.Value, recordInfo.Top);
                sections.Add(section);
            }
            // types with multiple sections will be stored once
            _ = linked.TryAdd(recordInfo.Top, recordInfo);

            if (recordInfo.Top.TryKeyInfo(supplement, out var primary))
                keyInfo[recordInfo.Top] = primary.Value;
        }

        FillBaseInfo(supplement, keyInfo, linked);

        return new Meta424()
        {
            Info = info.ToFrozenDictionary(),
            Types = types.ToFrozenDictionary(),
            Keys = keyInfo.ToFrozenDictionary(),
            Base = linked.ToFrozenDictionary(),
            Sections = [.. sections]
        };
    }

    internal SectionAttribute[] Sections { get; init; }

    internal FrozenDictionary<Section, Type> Types { get; init; }

    internal FrozenDictionary<Section, RecordInfo> Info { get; init; }

    internal FrozenDictionary<Type, KeyInfo> Keys { get; init; }

    internal FrozenDictionary<Type, BaseInfo> Base { get; init; }
}
