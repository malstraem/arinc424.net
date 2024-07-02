using System.Reflection;

namespace Arinc424.Linking;

internal abstract class Link<TRecord>
{
    internal abstract bool TryGetReference(string @string, Meta424 meta, out Reference? reference);
}

internal class Link<TRecord, TType>(Range foreign, Range? icao, Range? port, PropertyInfo property, TypeAttribute? typeAttribute)
    : Link<TRecord> where TRecord : Record424 where TType : class
{
    private readonly TypeAttribute? typeAttribute = typeAttribute;

    private readonly Foreign foreign = new Foreign<TType>(foreign, icao, port);

    private readonly Action<TRecord, TType> set = property.GetSetMethod()!.CreateDelegate<Action<TRecord, TType>>();

    internal override bool TryGetReference(string @string, Meta424 meta, out Reference? reference)
    {
        string key;

        reference = null;

        var type = property.PropertyType;

        if (typeAttribute is null)
        {
            if (foreign.TryGetKey(@string, meta.TypeInfo[type], out key))
            {
                reference = new(key, type, property);
                return true;
            }
            return false;
        }

        char section = @string[typeAttribute.SectionIndex];
        char subsection = @string[typeAttribute.SubsectionIndex];

        if (char.IsWhiteSpace(section) && char.IsWhiteSpace(subsection))
            return false;

        if (meta.Types.TryGetValue((section, subsection), out type) && foreign.TryGetKey(@string, meta.TypeInfo[type], out key))
        {
            reference = new(key, type, property);
            return true;
        }
        return false;
    }
}
