using System.Reflection;

using Arinc424.Attributes;
using Arinc424.Linking;

namespace Arinc424;

internal static class Meta424
{
    static Meta424()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            if (type.IsSubclassOf(typeof(Record424)) && !type.IsAbstract)
            {
                RecordTypes.Add(type);

                if (LinkingInfo.TryCreate(type, out var linkingInfo))
                    LinkingInfos.Add(type, linkingInfo!);
            }

            var recordAttribute = type.GetCustomAttribute<RecordAttribute>();

            if (recordAttribute is null)
                continue;

            var sequencedAttribute = type.GetCustomAttribute<SequencedAttribute>();

            var recordInfo = sequencedAttribute is null
                ? new RecordInfo(type, recordAttribute)
                : new SequencedRecordInfo(type, recordAttribute, sequencedAttribute);

            RecordInfos.Add(type, recordInfo);

            SpecTypes.Add((recordInfo.sectionChar, recordInfo.subsectionChar), type);
        }
    }

    internal static List<Type> RecordTypes { get; } = [];

    internal static Dictionary<Type, RecordInfo> RecordInfos { get; } = [];

    internal static Dictionary<Type, LinkingInfo> LinkingInfos { get; } = [];

    internal static Dictionary<(char, char), Type> SpecTypes { get; } = [];
}
