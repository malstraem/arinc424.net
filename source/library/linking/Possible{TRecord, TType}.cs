using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class Possible<TRecord, TType>(LinkInfo info, PropertyInfo property, Type[] types) : Known<TRecord, TType>(info, property)
    where TRecord : Record424
    where TType : Record424
{
    private readonly Type[] types = types;

    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        foreach (var type in types)
        {
            var info = meta.TypeInfo[type];

            if (unique.TryGetRecords(info.Type, out var records)
               && foreign.TryGetKey(record.Source!, info.Primary! /*guarantee by design*/, out string? key)
               && records.TryGetValue(key, out var referenced))
            {
                set(record, (TType)referenced);
                meta.TypeInfo[type].Relations!.Process(type, referenced, record);
                return true;
            }
        }
        diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
        return false;
    }
}
