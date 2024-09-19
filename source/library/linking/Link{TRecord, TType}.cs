using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Link<TRecord> where TRecord : Record424
{
    internal abstract bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic);
}

internal class Link<TRecord, TType>(KeyInfo info, PropertyInfo property) : Link<TRecord>
    where TRecord : Record424
    where TType : class
{
    protected readonly Foreign foreign = new(info);

    protected readonly PropertyInfo property = property;

    protected readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        diagnostic = null;

        var type = property.PropertyType;

        if (!foreign.TryGetKey(record.Source!, meta.TypeInfo[property.PropertyType].Primary! /*garantee by design*/, out string? key))
            return true;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.NoOneFound);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new InvalidLink(record, property, foreign.Info, LinkError.KeyNotFound) { Key = key };
            Debug.WriteLine(diagnostic);
            return false;
        }

        set(record, Unsafe.As<TType>(referenced)); /*garantee by design*/

        meta.TypeInfo[type].Relations.Process(type, referenced, record);

        return true;
    }
}
