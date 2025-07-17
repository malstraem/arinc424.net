using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Diagnostics;

internal class Known<TRecord, TForeign, TType>(PropertyInfo property, in KeyInfo info) : Link<TRecord>(property, in info)
    where TRecord : Record424
    where TForeign : IForeign
    where TType : class
{
    protected readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        var type = property.PropertyType;

        var primary = unique.meta.TypeInfo[type].Primary!.Value; /* guarantee by design */

        if (!TForeign.TryGetKey(record.Source!, in info, in primary, out string? key))
            return true;

        if (unique.TryGetRecords(type, out var records)
         && records.TryGetValue(key, out var referenced))
        {
            set(record, Unsafe.As<TType>(referenced)); /* guarantee by design */
            diagnostic = null;
            return true;
        }
        diagnostic = BadLink(record, type, LinkError.KeyNotFound);
        return false;
    }
}
