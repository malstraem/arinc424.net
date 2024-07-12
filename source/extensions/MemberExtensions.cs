using System.Diagnostics.CodeAnalysis;
using System.Reflection;

using Arinc424.Attributes;

namespace Arinc424.Building;

internal static class MemberExtensions
{
    internal static bool TryCharacterAttribute<TRecord>(this MemberInfo member, Supplement supplement, [NotNullWhen(true)] out CharacterAttribute? character)
        where TRecord : Record424
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

    internal static bool TryFieldAttribute<TRecord>(this MemberInfo member, Supplement supplement, [NotNullWhen(true)] out FieldAttribute? field)
        where TRecord : Record424
    {
        var attributes = member.GetCustomAttributes<FieldAttribute>().ToList();

        if (attributes.Count == 0)
        {
            field = null;
            return false;
        }

        List<FieldAttribute> fields = [];

        foreach (var attribute in attributes)
        {
            if (attribute.IsMatch<TRecord>())
                fields.Add(attribute);
        }

        var match = fields.Count == 0 ? attributes : fields;

        var skipped = match.SkipWhile(x => x.Supplement < supplement).ToArray();

        field = skipped.Length == 0 ? match.FirstOrDefault() : skipped.LastOrDefault();

        return field is not null;
    }
}
