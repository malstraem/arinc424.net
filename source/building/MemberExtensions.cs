using System.Reflection;

namespace Arinc424.Building;

internal static class MemberExtensions
{
    internal static bool TryCharacterAttribute(this MemberInfo member, Type type, out CharacterAttribute? characterAttribute)
    {
        var attributes = member.GetCustomAttributes<CharacterAttribute>();

        characterAttribute = attributes.FirstOrDefault();

        foreach (var attribute in attributes)
        {
            if (attribute is TargetCharacterAttribute target && (target.TargetType == type || type.IsSubclassOf(target.TargetType)))
            {
                characterAttribute = target;
                break;
            }
        }
        return characterAttribute is not null;
    }

    internal static bool TryFieldAttribute(this MemberInfo member, Type type, out FieldAttribute? fieldAttribute)
    {
        var attributes = member.GetCustomAttributes<FieldAttribute>();

        fieldAttribute = attributes.FirstOrDefault();

        foreach (var attribute in attributes)
        {
            if (attribute is TargetFieldAttribute target && (target.TargetType == type || type.IsSubclassOf(target.TargetType)))
            {
                fieldAttribute = target;
                break;
            }
        }
        return fieldAttribute is not null;
    }
}
