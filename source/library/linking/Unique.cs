using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Ground;
using Building;
using Diagnostics;

/**<summary>
Container with records that have unique keys.
</summary>*/
internal class Unique
{
    private FrozenDictionary<string, Record424> ports;

    private FrozenDictionary<Type, FrozenDictionary<string, Record424>> unique;

    internal readonly Meta424 meta;

    [Obsolete("todo: diagnostics")]
    private void Process(Build build, RecordInfo info, Dictionary<string, Record424> records)
    {
        var record = build.Record;

        var primary = info.Primary!.Value;

        if (!primary.TryGetKey(record.Source, out string? key))
        {
            Debug.WriteLine("oops");
            return;
        }

        if (!records.TryGetValue(key, out var collision))
        {
            records[key] = record;
            return;
        }
        build.Diagnostics ??= [];
        build.Diagnostics.Enqueue(new Duplicate
        {
            Key = key,
            Type = info.Composition.Top,
            Info = primary,
            Record = record,
            Collision = collision
        });
    }

    private void Fill(Dictionary<Section, Dictionary<Type, Queue<Build>>> builds)
    {
        RecordInfo airport = meta.TypeInfo[typeof(Airport)],
                   heliport = meta.TypeInfo[typeof(Heliport)];

        Dictionary<string, Record424> ports = [];
        Dictionary<Type, Dictionary<string, Record424>> unique = [];

        foreach (var (section, info) in meta.Info)
        {
            if (info.Primary is null)
                continue;

            var top = info.Composition.Top;

            if (!unique.TryGetValue(top, out var records))
                unique[top] = records = [];

            foreach (var build in builds[section][top])
                Process(build, info, records);

            if (info == airport || info == heliport)
            {
                foreach (var build in builds[section][info.Composition.Top])
                    Process(build, info, ports);
            }
        }
        this.ports = ports.ToFrozenDictionary();
        this.unique = unique.Select(x => KeyValuePair.Create(x.Key, x.Value.ToFrozenDictionary())).ToFrozenDictionary();
    }

    internal Unique(Parser424 parser)
    {
        meta = parser.meta;

        Fill(parser.builds);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out FrozenDictionary<string, Record424>? records)
        => unique.TryGetValue(type, out records);

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetPort(string key, [NotNullWhen(true)] out Record424? port)
        => ports.TryGetValue(key, out port);
}
