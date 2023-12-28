using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;

namespace Arinc.Spec424.Building;

internal record BuildInfo
{
    private static bool TryFieldAttribute(PropertyInfo property, out FieldAttribute fieldAttribute)
    {
        fieldAttribute = property.GetCustomAttributes<FieldAttribute>().SingleOrDefault(attribute => attribute is not TargetFieldAttribute)!;
        return fieldAttribute is not null;
    }

    private static bool TryCharacterAttribute(PropertyInfo property, out CharacterAttribute characterAttribute)
    {
        characterAttribute = property.GetCustomAttributes<CharacterAttribute>().SingleOrDefault(attribute => attribute is not TargetCharacterAttribute)!;
        return characterAttribute is not null;
    }

    private static bool TryTargetFieldAttribute(PropertyInfo property, Type targetType, out FieldAttribute targetFieldAttribute)
    {
        targetFieldAttribute = property.GetCustomAttributes<TargetFieldAttribute>().SingleOrDefault(attribute => attribute.TargetType == targetType)!;
        return targetFieldAttribute is not null;
    }

    private static bool TryTargetCharacterAttribute(PropertyInfo property, Type targetType, out CharacterAttribute targetCharacterAttribute)
    {
        targetCharacterAttribute = property.GetCustomAttributes<TargetCharacterAttribute>().SingleOrDefault(attribute => attribute.TargetType == targetType)!;
        return targetCharacterAttribute is not null;
    }

    internal BuildInfo(Type type, Type? targetType = null)
    {
        Constructor = type.GetConstructor([]) ?? throw new Exception($"Parameterless constructor was not found for `{type}`");

        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<HiddenAttribute>() is not null)
                continue;

            var validationAttribute = property.GetCustomAttribute<ValidationAttribute>();

            if ((targetType is not null && TryTargetFieldAttribute(property, targetType, out var fieldAttribute))
                || TryFieldAttribute(property, out fieldAttribute))
            {
                RangeInfo.Add(new RangeAssignmentInfo
                {
                    Property = property,
                    Range = fieldAttribute.Range,
                    Regex = validationAttribute?.Regex,
                    Decode = property.GetCustomAttribute<DecodeAttribute>()
                });
                continue;
            }

            if ((targetType is not null && TryTargetCharacterAttribute(property, targetType, out var characterAttribute))
                || TryCharacterAttribute(property, out characterAttribute))
            {
                IndexInfo.Add(new IndexAssignmentInfo
                {
                    Property = property,
                    Index = characterAttribute.Index,
                    Regex = validationAttribute?.Regex,
                    Transform = property.GetCustomAttribute<TransformAttribute>()
                });
                //continue;
            }

            /*var exception = targetType is null
                ? new Exception($"No `{nameof(CharacterAttribute)}` or `{nameof(FieldAttribute)}` was found, length of the `{property}` property is unknown")
                : new Exception($"No `{nameof(TargetCharacterAttribute)}` or `{nameof(TargetFieldAttribute)}` for '{targetType}' type was found, length of the `{property}` property is unknown");

            throw exception;*/
        }
    }

    internal ConstructorInfo Constructor { get; }

    internal List<IndexAssignmentInfo> IndexInfo { get; } = [];

    internal List<RangeAssignmentInfo> RangeInfo { get; } = [];
}
