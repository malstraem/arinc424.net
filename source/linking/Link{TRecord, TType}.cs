using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Link<TRecord>(TypeAttribute? typeAttribute) where TRecord : Record424
{
    protected Type type = typeof(TRecord);

    protected (int Section, int Subsection)? indexes = typeAttribute is null ? null
        : (typeAttribute.SectionIndex, typeAttribute.SubsectionIndex);

    internal abstract bool TryLink(TRecord record, Unique unique, Meta424 meta, out Diagnostic? diagnostic);
}

internal sealed class Link<TRecord, TType>(KeyRanges ranges, PropertyInfo property, TypeAttribute? typeAttribute) : Link<TRecord>(typeAttribute)
    where TRecord : Record424
    where TType : class
{
    private readonly Foreign<TType> foreign = new(ranges);

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, [NotNullWhen(false)] out Diagnostic? diagnostic)
    {
        if (!TryGetReference(record, meta, out var reference, out diagnostic))
            return diagnostic is null;

        (string key, var type) = reference.Value;

        if (!unique.TryGetRecords(type, out var records))
        {
            diagnostic = new LinkDiagnostic(record, $"No records of type '{type}' were found.", foreign.Ranges, indexes);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (!records.TryGetValue(key, out var referenced))
        {
            diagnostic = new LinkDiagnostic(record, $"'{type}' record with key '{key}' was not found.", foreign.Ranges, indexes);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (referenced is not TType @ref)
        {
            diagnostic = new LinkDiagnostic(record, $"'{type}' entity with key '{key}' is not a '{typeof(TType).Name}' type reference.", foreign.Ranges, indexes);
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

    internal bool TryGetReference(TRecord record, Meta424 meta, [NotNullWhen(true)] out (string, Type)? reference, out Diagnostic? diagnostic)
    {
        string key;

        reference = null;
        diagnostic = null;

        var type = property.PropertyType;

        string @string = record.Source!;

        if (indexes is null)
        {
            if (foreign.TryGetKey(@string, meta.TypeInfo[type].Primary! /*garantee by design*/, out key))
            {
                reference = (key, type);
                return true;
            }
            return false;
        }

        var (index, subindex) = indexes.Value;

        char section = @string[index];
        char subsection = @string[subindex];

        if (char.IsWhiteSpace(section) && char.IsWhiteSpace(subsection))
            return false;

        if (!meta.Types.TryGetValue((section, subsection), out type))
        {
            diagnostic = new LinkDiagnostic(record, $"Section '{section}, {subsection}' does not exist.", foreign.Ranges, indexes);
            Debug.WriteLine(diagnostic);
            return false;
        }

        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            diagnostic = new LinkDiagnostic(record, $"Record type '{type} does not have unique key.", foreign.Ranges, indexes);
            Debug.WriteLine(diagnostic);
            return false;
        }

        if (foreign.TryGetKey(@string, primary, out key))
        {
            reference = (key, type);
            return true;
        }
        return false;
    }
}
