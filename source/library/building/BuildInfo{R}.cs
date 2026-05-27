using System.Reflection;

namespace Arinc424.Building;

internal class BuildInfo<R>
    where R : Record424
{
    private static IndexAssignment<R> GetAssignment(
        Supplement supplement,
        PropertyInfo property,
        int index)
    {
        // prefer transform attached to the property
        if (!property.TryAttribute<R, TransformAttribute>(supplement, out var transform))
            _ = property.PropertyType.TryAttribute<R, TransformAttribute>(supplement, out transform);

        return transform is not null
            ? (IndexAssignment<R>)Activator.CreateInstance(
                typeof(TransformAssignment<,>).MakeGenericType(typeof(R), property.PropertyType),
                property,
                index,
                transform)!

            : new CharAssignment<R>(property, index)!;
    }

    private static RangeAssignment<R> GetAssignment(
        PropertyInfo property,
        Supplement supplement,
        Range range)
    {
        var type = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;

        // prefer decode attached to the property
        if (!property.TryAttribute<R, DecodeAttribute>(supplement, out var decode))
        {
            var propType = type.IsArray ? type.GetElementType()! : type;

            _ = propType.TryAttribute<R, DecodeAttribute>(supplement, out decode);
        }
        return decode is not null
            ? type.IsArray
                ? (RangeAssignment<R>)Activator.CreateInstance(
                    typeof(ArrayAssignment<,>).MakeGenericType(typeof(R), type.GetElementType()!),
                    property,
                    range,
                    decode,
                    property.GetCustomAttribute<CountAttribute>()!.Count)!

                : (RangeAssignment<R>)Activator.CreateInstance(
                    typeof(DecodeAssignment<,>).MakeGenericType(typeof(R), type),
                    property,
                    range,
                    decode)!

            : new StringAssignment<R>(property, range);
    }

    internal BuildInfo(Supplement supplement)
    {
        List<Assignment<R>> assignments = [];

        foreach (var property in typeof(R).GetProperties())
        {
            if (property.TryAttribute<R, CharacterAttribute>(supplement, out var character))
            {
                assignments.Add(GetAssignment(supplement, property, character.Index));
            }
            else if (property.TryAttribute<R, FieldAttribute>(supplement, out var field))
            {
                assignments.Add(GetAssignment(property, supplement, field.Range));
            }
        }
        Assignments = [.. assignments];
    }

    internal Assignment<R>[] Assignments { get; }
}
