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
        diagnostic = null;

        var type = property.PropertyType;

        var primary = unique.meta.TypeInfo[type].Primary!.Value; /* guarantee by design */

        if (!TForeign.TryGetKey(record.Source!, in info, in primary, out string? key))
            return true;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new InvalidLink(record, property, in info, LinkError.NoOneFound);
            return false;
        }
        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, in info, LinkError.KeyNotFound) { Key = key };
            return false;
        }
        set(record, Unsafe.As<TType>(referenced)); /* guarantee by design */
        return true;
    }
}
