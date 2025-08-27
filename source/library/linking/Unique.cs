using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

/**<summary>
Container with records that have unique keys.
</summary>*/
internal class Unique
{
    private FrozenDictionary<Type, FrozenDictionary<string, Record424>> unique;
#pragma warning disable CS8618
    private Unique() { }
#pragma warning restore CS8618
    private static void Process(Build build, Type type, KeyInfo primary, Dictionary<string, Record424> records)
    {
        var record = build.Record;

        if (!primary.TryGetKey(record.Source, out string? key))
            return;

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

    internal static Unique Create(Builds builds, Meta424 meta)
    {
        Dictionary<Type, Dictionary<string, Record424>> unique = [];

        foreach (var (type, info) in meta.Base)
        {
            if (!meta.Keys.TryGetValue(type, out var primary))
                continue;

            if (!unique.TryGetValue(type, out var records))
                unique[type] = records = [];

            foreach (var build in builds[type])
                Process(build, type, primary, records);
        }
        return new Unique()
        {
            unique = unique.Select(x => KeyValuePair.Create(x.Key, x.Value.ToFrozenDictionary()))
                .ToFrozenDictionary()
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out FrozenDictionary<string, Record424>? records)
        => unique.TryGetValue(type, out records);
}
