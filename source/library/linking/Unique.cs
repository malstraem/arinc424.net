using System;
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
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("todo: diagnostics")]
    private void ProcessPrimaryKey(Build build, RecordInfo info)
    {
        var record = build.Record;

        if (!info.Primary!.TryGetKey(record.Source, out string? key))
        {
            Debug.WriteLine("oops");
            return;
        }

        if (unique[info.TopLevel].TryAdd(key, record))
            return;

        build.Diagnostics ??= [];
        build.Diagnostics.Enqueue(new Duplicate(record, info.TopLevel, key));
    }

    internal Unique(Meta424 meta, Parser424 parser)
    {
        foreach (var (section, info) in meta.Info)
        {
            if (info.Primary is null)
                continue;

            if (!unique.ContainsKey(info.TopLevel))
                unique[info.TopLevel] = [];

            foreach (var build in parser.builds[section.Value][info.TopLevel])
            {
                ProcessPrimaryKey(build, info);
            }
        };
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    internal bool TryGetRecords(Type type, [NotNullWhen(true)] out Dictionary<string, Record424>? records) => unique.TryGetValue(type, out records);
}
