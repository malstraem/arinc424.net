using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Link<TRecord> where TRecord : Record424
{
    internal abstract bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic);
}

internal class Link<TRecord, TType>(KeyInfo ranges, PropertyInfo property) : Link<TRecord>
    where TRecord : Record424
    where TType : class
{
    protected readonly Foreign foreign = new(ranges);

    protected readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    private bool TryGetReference(TRecord record, Meta424 meta, [NotNullWhen(true)] out (string, Type, Section)? reference, out Diagnostic? diagnostic)
    {
        reference = null;
        diagnostic = null;

        var type = property.PropertyType;

        string @string = record.Source!;

        var info = meta.TypeInfo[type];

        if (foreign.TryGetKey(@string, info.Primary! /*garantee by design*/, out string? key))
        {
            reference = (key, type, info.Section);
            return true;
        }
        return false;
    }

    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!TryGetReference(record, meta, out var reference, out diagnostic))
            return diagnostic is null;

        (string key, var type, var section) = reference.Value;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new LinkDiagnostic(record, $"No records of type '{type}' were found.", foreign.Info);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new LinkDiagnostic(record, $"'{type}' record with key '{key}' was not found.", foreign.Info);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (referenced is not TType @ref)
        {
            diagnostic = new LinkDiagnostic(record, $"'{type}' entity with key '{key}' is not a '{typeof(TType).Name}' type reference.", foreign.Info);
            Debug.WriteLine(diagnostic);
            return false;
        }

        set(record, @ref);

        var relations = meta.TypeInfo[type].Relations;

        // todo: compiled one & many relations
        if (relations.many.TryGetValue(type, out var property))
        {
            if (property.GetValue(referenced) is not List<TRecord> value)
                property.SetValue(referenced, value = []);

            value.Add(record);
        }
        else if (relations.one.TryGetValue(type, out property))
        {
            property.SetValue(referenced, record);
        }
        return true;
    }
}
