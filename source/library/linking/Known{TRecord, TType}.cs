using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

internal sealed class Known<TRecord, TType>(PropertyInfo property, KeyInfo info) : Link<TRecord>(property, info)
    where TRecord : Record424
    where TType : class
{
    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    private BadKnown Bad(LinkError error, TRecord record, Type type, string? key = null) => new()
    {
        Info = info,
        Property = property,
        Key = key,
        Type = type,
        Error = error,
        Record = record
    };

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        var type = property.PropertyType;

        var primary = unique.meta.Keys[type]; /* guarantee by design */

        if (!info.TryGetKey(record.Source!, primary, out string? key))
        {
            if (nullState == NullabilityState.NotNull)
            {
                diagnostic = Bad(LinkError.Null, record, type);
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
        diagnostic = Bad(LinkError.KeyNotFound, record, type, key);
        return false;
    }
}
