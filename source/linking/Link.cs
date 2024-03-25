using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Linking;

internal class Link
{
    internal Link(PropertyInfo property, IEnumerable<ForeignAttribute> foreignAttributes, TypeAttribute? typeAttribute)
    {
        Property = property;

        Foreigns = foreignAttributes;

        TypeAttribute = typeAttribute;
    }

    internal bool TryGetKey(Type linkType, string @string, out string key)
    {
        key = string.Empty;

        foreach (var foreign in Foreigns)
        {
            if (foreign is TypedForeignAttribute exceptAttribute && !exceptAttribute.Types.Contains(linkType))
                continue;

            key += @string[foreign.Range].Trim();
        }

        return !string.IsNullOrEmpty(key);
    }

    internal bool TryGetType(string @string, out Type type)
    {
        type = Property.PropertyType;

        if (TypeAttribute is null)
            return true;

        char section = @string[TypeAttribute.SectionIndex];
        char subsection = @string[TypeAttribute.SubsectionIndex];

        if (char.IsWhiteSpace(section) && char.IsWhiteSpace(subsection))
            return false;

        if (Meta424.SpecTypes.TryGetValue((section, subsection), out var specType))
        {
            type = specType;
            return true;
        }
        return false;
    }

    internal IEnumerable<ForeignAttribute> Foreigns { get; }

    internal PropertyInfo Property { get; }

    internal TypeAttribute? TypeAttribute { get; }
}
