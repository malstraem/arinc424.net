using System.Reflection;

using Arinc424.Attributes;

namespace Arinc424.Relations;

internal class Link(PropertyInfo property, ForeignAttribute[] foreigns, TypeAttribute? typeAttribute)
{
    private bool TryGetKey(string @string, Type type, out string key)
    {
        key = string.Empty;

        foreach (var foreign in foreigns)
        {
            if (foreign is TypedForeignAttribute foreignAttribute && !foreignAttribute.Types.Contains(type))
                continue;

            key += @string[foreign.Range].Replace(" ", null); // potentially need faster (unsafe?) way
        }

        return !string.IsNullOrEmpty(key);
    }

    internal bool TryGetReference(string @string, out Reference? reference)
    {
        string key;

        reference = null;

        var type = property.PropertyType;

        if (typeAttribute is null)
        {
            if (TryGetKey(@string, type, out key))
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

        if (Meta424.Types.TryGetValue((section, subsection), out type) && TryGetKey(@string, type, out key))
        {
            reference = new(key, type, property);
            return true;
        }
        return false;
    }
}
