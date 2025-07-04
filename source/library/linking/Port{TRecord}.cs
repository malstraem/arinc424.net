using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal sealed class Port<TRecord>(LinkInfo info, PropertyInfo property) : Known<TRecord, Ground.Port>(info, property)
    where TRecord : Record424
{
    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
       /* diagnostic = null;


        var info = unique.meta.TypeInfo[type];

        if (unique.TryGetRecords(info.Composition.Top, out var records)
            && foreign.TryGetKey(record.Source!, info.Primary! *//*guarantee by design*//*, out string? key)
            && records.TryGetValue(key, out var referenced))
        {
            set(record, (TType)referenced);
            unique.meta.TypeInfo[type].Relations!.Process(referenced, record);
            return true;
        }

        diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);*/
        return false;
    }
}
