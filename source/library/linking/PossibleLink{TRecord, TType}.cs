using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class PossibleLink<TRecord, TType>(KeyInfo ranges, PropertyInfo property, Type[] types) : Link<TRecord, TType>(ranges, property)
    where TRecord : Record424
    where TType : Record424
{
    private readonly Type[] types = types;

    [Obsolete("todo")]
    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        foreach (var type in types)
        {
            var info = meta.TypeInfo[type];

            if (!(unique.TryGetRecords(info.Type, out var records)
               && foreign.TryGetKey(record.Source!, info.Primary! /*garantee by design*/, out string? key)
               && records.TryGetValue(key, out var referenced)))
            {
                continue;
            }
            set(record, (TType)referenced);

            meta.TypeInfo[type].Relations.Process(type, referenced, record);
        }
        return false; // todo diagnostics
    }
}
