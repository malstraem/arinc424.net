using System.Reflection;

using Arinc424.Attributes;

namespace Arinc424.Linking;

internal class Link(PropertyInfo property, ForeignAttribute[] foreigns, TypeAttribute? typeAttribute)
{
    private bool TryGetKey(string @string, Type linkType, out string key)
    {
        key = string.Empty;

        foreach (var foreign in foreigns)
        {
            if (foreign is TypedForeignAttribute exceptAttribute && !exceptAttribute.Types.Contains(linkType))
                continue;

            key += @string[foreign.Range].Replace(" ", null); // potentially need faster (unsafe?) way
        }

        return !string.IsNullOrEmpty(key);
    }

    internal bool TryGetKeyType(string @string, out string? key, out Type type)
    {
        key = null;
        type = Property.PropertyType;

        if (typeAttribute is null)
            return TryGetKey(@string, type, out key);

        char section = @string[typeAttribute.SectionIndex];
        char subsection = @string[typeAttribute.SubsectionIndex];

        if (char.IsWhiteSpace(section) && char.IsWhiteSpace(subsection))
            return false;

        if (Meta424.SpecTypes.TryGetValue((section, subsection), out var specType))
        {
            type = specType;
            return TryGetKey(@string, type, out key);
        }
        return false;
    }

    internal PropertyInfo Property { get; } = property;
}
