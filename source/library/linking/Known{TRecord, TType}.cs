using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Link<TRecord> where TRecord : Record424
{
    internal abstract bool TryLink(TRecord record, Unique unique, [NotNullWhen(false)] out Diagnostic? diagnostic);
}

internal class Known<TRecord, TType>(LinkInfo info, PropertyInfo property) : Link<TRecord> where TRecord : Record424 where TType : class
{
    protected readonly Foreign foreign = new(info);

    protected readonly PropertyInfo property = property;

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
        // guarantee by design
        set(record, Unsafe.As<TType>(referenced));

        meta.TypeInfo[type].Relations?.Process(referenced, record);

        return true;
    }
}
