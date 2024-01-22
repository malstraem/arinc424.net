using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;

[assembly: OneToMany<Airport, Runway>]
[assembly: OneToMany<Airport, AirportApproach>]
[assembly: OneToMany<Airport, StandardInstrumentDeparture>]
[assembly: OneToMany<Airport, StandardTerminalArrival>]
[assembly: OneToMany<Airport, VeryHighFrequencyAid>]
[assembly: OneToMany<Airport, NonDirectionalBeacon>]

namespace Arinc.Spec424;

internal static class Meta424
{
    static Meta424()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            var recordAttribute = type.GetCustomAttribute<RecordAttribute>();

            if (recordAttribute is null)
                continue;

            var sequencedAttribute = type.GetCustomAttribute<SequencedAttribute>();

            var recordInfo = sequencedAttribute is null
                ? new RecordInfo(type, recordAttribute)
                : new SequencedRecordInfo(type, recordAttribute, sequencedAttribute);

            RecordInfo.Add(type, recordInfo);

            var externalAttribute = type.GetCustomAttribute<ExternalAttribute>();

            if (externalAttribute is not null)
                LinkedInfo.Add(type, new ExternalLinkedInfo(type, externalAttribute));
        }
    }

    internal static Dictionary<Type, RecordInfo> RecordInfo { get; } = [];

    internal static Dictionary<Type, ExternalLinkedInfo> LinkedInfo { get; } = [];
}
