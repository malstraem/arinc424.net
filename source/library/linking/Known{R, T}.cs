using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

internal sealed class Known<R, T>(PropertyInfo property, KeyInfo info) : Link<R>(property, info)
    where R : Record424
    where T : class
{
    private readonly Action<R, T> set = property.GetSetMethod()!.CreateDelegate<Action<R, T>>();

    private BadKnown Bad(LinkError error, R record, Type type, string? key = null) => new()
    {
        Info = info,
        Property = property,
        Key = key,
        Type = type,
        Error = error,
        Record = record
    };

    internal override bool TryLink(
        R record,
        Unique unique,
        Meta424 meta,
        [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        var type = property.PropertyType;

        var primary = meta.Keys[type]; /* guarantee by design */

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
            set(record, Unsafe.As<T>(referenced)); /* guarantee by design */
            diagnostic = null;
            return true;
        }
        diagnostic = Bad(LinkError.KeyNotFound, record, type, key);
        return false;
    }
}
