using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

using Diagnostics;

internal class Known<TRecord, TForeign, TType>(TForeign foreign, PropertyInfo property) : Link<TRecord>(property)
    where TRecord : Record424
    where TForeign : IForeign<TForeign>
    where TType : class
{
    protected readonly TForeign foreign = foreign;

    protected readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        var type = property.PropertyType;

        if (!foreign.TryGetKey(record.Source!, unique.meta.TypeInfo[type].Primary! /* guarantee by design */, out string? key))
            return true;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
            return false;
        }
        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.KeyNotFound) { Key = key };
            return false;
        }
        set(record, Unsafe.As<TType>(referenced)); /* guarantee by design */
        return true;
    }
}
