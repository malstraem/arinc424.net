using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

/**<summary>
Container with records that have unique keys.
</summary>*/
internal class Unique
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    internal readonly Meta424 meta;

    [Obsolete("todo: diagnostics")]
    private void ProcessPrimaryKey(Build build, RecordInfo info)
    {
        var record = build.Record;

        if (!info.Primary!.TryGetKey(record.Source, out string? key))
        {
            Debug.WriteLine("oops");
            return;
        }

        if (unique[info.Composition.Top].TryAdd(key, record))
            return;

        build.Diagnostics ??= [];
        build.Diagnostics.Enqueue(new Duplicate(record, info.Composition.Top, key));
    }

    internal Unique(Parser424 parser)
    {
        meta = parser.meta;

        foreach (var (section, info) in parser.meta.Info)
        {
            if (info.Primary is null)
                continue;

            if (!unique.ContainsKey(info.Composition.Top))
                unique[info.Composition.Top] = [];

            foreach (var build in parser.builds[section][info.Composition.Top])
                ProcessPrimaryKey(build, info);
        }
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out Dictionary<string, Record424>? records) => unique.TryGetValue(type, out records);
}
