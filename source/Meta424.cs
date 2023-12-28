using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

internal class Meta424
{
    private static readonly Meta424 meta424 = new();

    static Meta424()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        foreach (var type in types)
        {
            var recordAttribute = type.GetCustomAttribute<RecordAttribute>();

            if (recordAttribute is not null)
            {
                var sequencedAttribute = type.GetCustomAttribute<SequencedAttribute>();

                var recordInfo = sequencedAttribute is null
                    ? new RecordInfo(type, recordAttribute)
                    : new SequencedRecordInfo(type, recordAttribute, sequencedAttribute);

                RecordInfo.Add(type, recordInfo);

                LinkInfo.Add(type, type.GetProperties().SelectMany(property => property.GetCustomAttributes<LinkAttribute>()));
                ReceiveInfo.Add(type, type.GetProperties().SelectMany(property => property.GetCustomAttributes<ReceiveAttribute>()));
            }
        }
    }

    internal static Dictionary<Type, RecordInfo> RecordInfo { get; } = [];

    internal static Dictionary<Type, IEnumerable<LinkAttribute>> LinkInfo { get; } = [];

    internal static Dictionary<Type, IEnumerable<ReceiveAttribute>> ReceiveInfo { get; } = [];
}
