using System.Reflection;

using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Link<TRecord>
{
    protected Type type = typeof(TRecord);

    internal abstract bool TryLink(TRecord record, Unique unique, Meta424 meta, out Diagnostic? diagnostic);

    internal abstract bool TryGetReference(string @string, Meta424 meta, out Reference? reference);
}

internal class Link<TRecord, TType>(KeyRanges ranges, PropertyInfo property, TypeAttribute? typeAttribute)
    : Link<TRecord> where TRecord : Record424 where TType : class
{
    private readonly TypeAttribute? typeAttribute = typeAttribute;

    private readonly Foreign<TType> foreign = new(ranges);

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    [Obsolete("todo: diagnostics")]
    internal override bool TryLink(TRecord record, Unique unique, Meta424 meta, out Diagnostic? diagnostic)
    {
        diagnostic = null;

        if (!TryGetReference(record.Source!, meta, out var reference))
            return false;

        if (!unique.unique.TryGetValue(reference!.Type, out var uniqueTypes))
        {
            // todo: diagnostic log
            Debug.WriteLine($"Entity type '{reference.Type} not found in unique types"); // TODO: logging path
            return false;
        }

        if (!uniqueTypes.TryGetValue(reference.Key, out var referenced))
        {
            // todo: diagnostic log
            Debug.WriteLine($"{reference.Type} entity with key '{reference.Key}' not found"); // TODO: logging path
            return false;
        }

        if (referenced is not TType @ref)
        {
            return false;
        }

        set(record, @ref);

        var relations = meta.TypeInfo[reference.Type].Relations;

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

    [Obsolete("todo: diagnostics")]
    internal override bool TryGetReference(string @string, Meta424 meta, out Reference? reference)
    {
        string key;

        reference = null;

        var type = property.PropertyType;

        if (typeAttribute is null)
        {
            if (foreign.TryGetKey(@string, meta.TypeInfo[type].Primary!, out key))
            {
                reference = new(key, type);
                return true;
            }
            return false;
        }

        char section = @string[typeAttribute.SectionIndex];
        char subsection = @string[typeAttribute.SubsectionIndex];

        if (char.IsWhiteSpace(section) && char.IsWhiteSpace(subsection))
            return false;

        if (!meta.TryGetType(section, subsection, out type))
        {
            Debug.WriteLine("oops");
            // todo: diagnostic
            return false;
        }

        var primary = meta.TypeInfo[type].Primary;

        if (primary is null)
        {
            Debug.WriteLine("oops");
            // todo: diagnostic
            return false;
        }

        if (foreign.TryGetKey(@string, primary, out key))
        {
            reference = new(key, type);
            return true;
        }
        return false;
    }
}
