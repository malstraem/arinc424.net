using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class PossibleLink<TRecord, TType>(KeyInfo ranges, PropertyInfo property, Type[] types) : Link<TRecord, TType>(ranges, property)
    where TRecord : Record424
    where TType : Record424
{
    private readonly Type[] types = types;

    private bool TryGetReference(TRecord record, RecordInfo info, [NotNullWhen(true)] out string? key, out Diagnostic? diagnostic)
    {
        diagnostic = null;

        string @string = record.Source!;

        return foreign.TryGetKey(@string, info.Primary! /*garantee by design*/, out key);
    }

    [Obsolete("todo")]
    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        foreach (var type in types)
        {
            var info = meta.TypeInfo[type];

            if (!TryGetReference(record, meta.TypeInfo[type], out string? key, out diagnostic))
                return diagnostic is null;

            if (!unique.TryGetRecords(info.Type, out var records))
                continue;

            if (!records.TryGetValue(key, out var referenced))
                continue;

            set(record, (TType)referenced);

            var relations = meta.TypeInfo[type].Relations;

            // todo: compiled one & many relations
            if (relations.many.TryGetValue(type, out var property))
            {
                if (property.GetValue(referenced) is not List<TRecord> value)
                    property.SetValue(referenced, value = []);

                value.Add(record);
            }
            else if (relations.one.TryGetValue(type, out property))
            {
                property.SetValue(referenced, record);
            }
            return true;
        }
        return false; // todo diagnostics
    }
}
