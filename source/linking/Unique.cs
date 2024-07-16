using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

/// <summary>
/// Container with records that have unique keys.
/// </summary>
internal class Unique
{
    internal readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("todo: diagnostics")]
    private void ProcessPrimaryKey(Build build, RecordInfo info)
    {
        var record = build.Record;

        if (!info.Primary!.TryGetKey(record.Source, out string? key))
        {
            Debug.WriteLine("oops");
            return;
        }

        if (unique[info.Type].TryAdd(key, record))
            return;

        build.Diagnostics ??= [];
        build.Diagnostics.Enqueue(new DuplicateDiagnostic(record, info.Type, key));
        Debug.WriteLine(build.Diagnostics.Last());
    }

    internal Unique(IEnumerable<RecordInfo> info, IDictionary<Section, IEnumerable<Build>> builds)
    {
        foreach (var attribute in info.Where(x => x.Primary is not null))
        {
            if (!unique.ContainsKey(attribute.Type))
                unique[attribute.Type] = [];

            foreach (var build in builds[attribute.Section])
                ProcessPrimaryKey(build, attribute);
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out Dictionary<string, Record424>? records) => unique.TryGetValue(type, out records);
}
