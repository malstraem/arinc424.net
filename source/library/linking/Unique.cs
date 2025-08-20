using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Diagnostics;

/**<summary>
Container with records that have unique keys.
</summary>*/
internal class Unique
{
    private FrozenDictionary<Type, FrozenDictionary<string, Record424>> unique;

    internal readonly Meta424 meta;

    [Obsolete("todo: diagnostics")]
    private void Process(Build build, Type type, in KeyInfo primary, Dictionary<string, Record424> records)
    {
        var record = build.Record;

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
            Type = type,
            Info = primary,
            Record = record,
            Collision = collision
        });
    }

    private void Fill(Parser424 parser)
    {
        Dictionary<Type, Dictionary<string, Record424>> unique = [];

        foreach (var (type, info) in meta.Base)
        {
            if (!meta.Keys.TryGetValue(type, out var primary))
                continue;

            if (!unique.TryGetValue(type, out var records))
                unique[type] = records = [];

            var sections = info.Sections.Select(x => x.Value);

            foreach (var section in sections)
            {
                foreach (var build in parser.builds[section][type])
                    Process(build, type, in primary, records);
            }
        }
        this.unique = unique.Select(x => KeyValuePair.Create(x.Key, x.Value.ToFrozenDictionary())).ToFrozenDictionary();
    }

    internal Unique(Parser424 parser)
    {
        meta = parser.meta;

        Fill(parser);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out FrozenDictionary<string, Record424>? records)
        => unique.TryGetValue(type, out records);
}
