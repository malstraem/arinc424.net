using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Diagnostics;

internal class Known<TRecord, TType>(PropertyInfo property, in KeyInfo info) : Link<TRecord>(property, in info)
    where TRecord : Record424
    where TType : class
{
    protected readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        var type = property.PropertyType;

        var primary = unique.meta.KeyInfo[type]; /* guarantee by design */

        if (!info.TryGetKey(record.Source!, in primary, out string? key))
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostic = BadLink(LinkError.Null, record, type);
                return false;
            }
            diagnostic = null;
            return true;
        }

        if (unique.TryGetRecords(type, out var records)
         && records.TryGetValue(key, out var referenced))
        {
            set(record, Unsafe.As<TType>(referenced)); /* guarantee by design */
            diagnostic = null;
            return true;
        }
        diagnostic = BadLink(LinkError.KeyNotFound, record, type, key);
        return false;
    }
}
