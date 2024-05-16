using System.Reflection;

namespace Arinc424.Building;

internal record BuildInfo
{
    private static bool TryFieldAttribute(PropertyInfo property, out FieldAttribute? fieldAttribute)
    {
        fieldAttribute = property.GetCustomAttributes<FieldAttribute>().SingleOrDefault(attribute => attribute is not TargetFieldAttribute);
        return fieldAttribute is not null;
    }

    private static bool TryCharacterAttribute(PropertyInfo property, out CharacterAttribute? characterAttribute)
    {
        characterAttribute = property.GetCustomAttributes<CharacterAttribute>().SingleOrDefault(attribute => attribute is not TargetCharacterAttribute);
        return characterAttribute is not null;
    }

    private static bool TryTargetFieldAttribute(PropertyInfo property, Type targetType, out FieldAttribute? targetFieldAttribute)
    {
        targetFieldAttribute = property.GetCustomAttributes<TargetFieldAttribute>()
            .SingleOrDefault(attribute => attribute.TargetType == targetType || targetType.IsSubclassOf(attribute.TargetType));

        return targetFieldAttribute is not null;
    }

    private static bool TryTargetCharacterAttribute(PropertyInfo property, Type targetType, out CharacterAttribute? targetCharacterAttribute)
    {
        targetCharacterAttribute = property.GetCustomAttributes<TargetCharacterAttribute>()
            .SingleOrDefault(attribute => attribute.TargetType == targetType || targetType.IsSubclassOf(attribute.TargetType));

        return targetCharacterAttribute is not null;
    }

    internal BuildInfo(Type type)
    {
        var properties = type.GetProperties();

        List<IndexAssignmentInfo> indexInfo = [];
        List<RangeAssignmentInfo> rangeInfo = [];

        foreach (var property in properties)
        {
            var validationAttribute = property.GetCustomAttribute<ValidationAttribute>();

            if (TryTargetFieldAttribute(property, type, out var fieldAttribute) || TryFieldAttribute(property, out fieldAttribute))
            {
                rangeInfo.Add(new RangeAssignmentInfo
                {
                    Property = property,
                    Range = fieldAttribute!.Range,
                    Regex = validationAttribute?.Regex,
                    Decode = property.GetCustomAttribute<DecodeAttribute>()
                });
            }
            else if (TryTargetCharacterAttribute(property, type, out var characterAttribute) || TryCharacterAttribute(property, out characterAttribute))
            {
                indexInfo.Add(new IndexAssignmentInfo
                {
                    Property = property,
                    Index = characterAttribute!.Index,
                    Regex = validationAttribute?.Regex,
                    Transform = property.GetCustomAttribute<TransformAttribute>()
                });
            }
        }
        IndexInfo = [.. indexInfo];
        RangeInfo = [.. rangeInfo];
    }

    internal IndexAssignmentInfo[] IndexInfo { get; }

    internal RangeAssignmentInfo[] RangeInfo { get; }
}
