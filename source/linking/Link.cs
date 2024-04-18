using System.Reflection;

using Arinc424.Attributes;

namespace Arinc424.Linking;

internal class Link
{
    private readonly ForeignKey foreignKey;

    private readonly PropertyInfo property;

    private readonly TypeAttribute? typeAttribute;

    internal bool TryGetReference(string @string, out Reference? reference)
    {
        string key;

        reference = null;

        var type = property.PropertyType;

        if (typeAttribute is null)
        {
            if (foreignKey.TryGetKey(@string, type, out key))
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

        if (Meta424.Types.TryGetValue((section, subsection), out type) && foreignKey.TryGetKey(@string, type, out key))
        {
            reference = new(key, type, property);
            return true;
        }
        return false;
    }

    internal Link(PropertyInfo property, ForeignAttribute[] foreignAttributes, TypeAttribute? typeAttribute)
    {
        this.property = property;
        this.typeAttribute = typeAttribute;

        foreignKey = ForeignKey.Create(foreignAttributes);
    }
}
