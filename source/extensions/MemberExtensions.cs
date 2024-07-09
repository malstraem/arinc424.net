using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Building;

internal static class MemberExtensions
{
    internal static bool TryCharacterAttribute<TRecord>(this MemberInfo member, [NotNullWhen(true)] out CharacterAttribute? character) where TRecord : Record424
    {
        var attributes = member.GetCustomAttributes<CharacterAttribute>();

        character = attributes.FirstOrDefault();

        foreach (var attribute in attributes)
        {
            if (attribute.IsMatch<TRecord>())
            {
                character = attribute;
                break;
            }
        }
        return character is not null;
    }

    internal static bool TryFieldAttribute<TRecord>(this MemberInfo member, [NotNullWhen(true)] out FieldAttribute? field) where TRecord : Record424
    {
        var attributes = member.GetCustomAttributes<FieldAttribute>();

        field = attributes.FirstOrDefault();

        foreach (var attribute in attributes)
        {
            if (attribute.IsMatch<TRecord>())
            {
                field = attribute;
                break;
            }
        }
        return field is not null;
    }
}
