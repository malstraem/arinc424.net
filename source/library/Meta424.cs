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
    private static FrozenDictionary<Type, (Relation, Section[])> GetMiddleInfo
    (
        Supplement supplement,
        Dictionary<Type, RecordInfo> typeInfo,
        Dictionary<Type, KeyInfo> keyInfo
    )
    {
        HashSet<Type> linkedTypes = [];

        foreach (var (_, recordInfo) in typeInfo)
        {
            var relations = recordInfo.Composition.Relations;

            if (relations is null)
                continue;

            foreach (var link in relations.Last().Links)
            {
                if (!link.IsPolymorph)
                    _ = linkedTypes.Add(link.Type);
            }
        }

        HashSet<Type> middleTypes = [];

        foreach (var (type, _) in typeInfo)
        {
            foreach (var linkedType in linkedTypes)
            {
                if (type.IsSubclassOf(linkedType))
                    _ = middleTypes.Add(linkedType);
            }
        }

        Dictionary<Type, (Relation, Section[])> middle = [];

        foreach (var middleType in middleTypes)
        {
            List<Section> middleSections = [];

            if (middleType.TryKeyInfo(supplement, out var key))
                keyInfo[middleType] = key.Value;

            foreach (var (type, info) in typeInfo)
            {
                if (type.IsSubclassOf(middleType))
                    middleSections.AddRange(info.Sections.Select(x => x.Value));
            }
            middle[middleType] = (Relation.Create(middleType, supplement)!, [.. middleSections]);
        }
        return middle.ToFrozenDictionary();
    }

    /**<summary>
    Creates metadata using target <paramref name="supplement"/>.
    </summary>
    <returns>Runtime compiled metadata.</returns>*/
    public static Meta424 Create(Supplement supplement)
    {
        List<SectionAttribute> sections = [];
        Dictionary<Section, Type> types = [];
        Dictionary<Type, RecordInfo> typeInfo = [];
        Dictionary<Section, RecordInfo> sectionInfo = [];
        Dictionary<Type, KeyInfo> keyInfo = [];

        var attributes = Assembly.GetExecutingAssembly().GetCustomAttributes<RecordAttribute>();

        foreach (var info in attributes.Select(x => x.GetInfo(supplement)))
        {
            foreach (var section in info.Sections)
            {
                types.Add(section.Value, info.Composition.Top);
                sections.Add(section);
                sectionInfo.Add(section.Value, info);
            }
            // types with multiple sections will be stored once
            _ = typeInfo.TryAdd(info.Composition.Top, info);

            if (info.Composition.Top.TryKeyInfo(supplement, out var primary))
                keyInfo[info.Composition.Top] = primary.Value;
        }

        var middleInfo = GetMiddleInfo(supplement, typeInfo, keyInfo);

        return new Meta424()
        {
            Info = sectionInfo.ToFrozenDictionary(),
            Types = types.ToFrozenDictionary(),
            KeyInfo = keyInfo.ToFrozenDictionary(),
            TypeInfo = typeInfo.ToFrozenDictionary(),
            Sections = [.. sections],
            MiddleInfo = middleInfo,
        };
    }

    internal SectionAttribute[] Sections { get; init; }

    internal FrozenDictionary<Section, Type> Types { get; init; }

    internal FrozenDictionary<Section, RecordInfo> Info { get; init; }

    internal FrozenDictionary<Type, RecordInfo> TypeInfo { get; init; }

    internal FrozenDictionary<Type, (Relation, Section[])> MiddleInfo { get; init; }

    internal FrozenDictionary<Type, KeyInfo> KeyInfo { get; init; }
}
