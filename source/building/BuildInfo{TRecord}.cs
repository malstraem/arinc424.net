using System.Reflection;

namespace Arinc424.Building;

internal class BuildInfo<TRecord> where TRecord : Record424
{
    private static IndexAssignment<TRecord> GetIndexAssignment(PropertyInfo property, Supplement supplement, int index)
    {
        // prefer transform attached to the property
        if (!property.TryAttribute<TRecord, TransformAttribute>(supplement, out var transform))
            _ = property.PropertyType.TryAttribute<TRecord, TransformAttribute>(supplement, out transform);

        return transform is not null
            ? (IndexAssignment<TRecord>)
                Activator.CreateInstance(typeof(TransformAssignment<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), property, index, transform)!

            : new CharAssignment<TRecord>(property, index)!;
    }

    private static RangeAssignment<TRecord> GetRangeAssignment(PropertyInfo property, Supplement supplement, Range range)
    {
        var (type, isValueNullable) = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? (property.PropertyType.GetGenericArguments().First(), true) // look inside Nullable<T> if that's the case
            : (property.PropertyType, false);

        // prefer decode attached to the property
        if (!property.TryAttribute<TRecord, DecodeAttribute>(supplement, out var decode))
        {
            var propType = type.IsArray ? type.GetElementType()! : type;

            _ = propType.TryAttribute<TRecord, DecodeAttribute>(supplement, out decode);
        }

        return decode is not null
            ? type.IsArray
                ? (RangeAssignment<TRecord>)
                    Activator.CreateInstance(typeof(ArrayAssignment<,>)
                        .MakeGenericType(typeof(TRecord), type.GetElementType()!), property, range, decode, property.GetCustomAttribute<CountAttribute>()!.Count)!

                : (RangeAssignment<TRecord>)
                    Activator.CreateInstance(typeof(DecodeAssignment<,>)
                        .MakeGenericType(typeof(TRecord), type), property, range, decode, isValueNullable)!

            : new StringAssignment<TRecord>(property, range);
    }

    internal BuildInfo(Supplement supplement)
    {
        List<Assignment<TRecord>> assignments = [];

        foreach (var property in typeof(TRecord).GetProperties())
        {
            if (property.TryAttribute<TRecord, CharacterAttribute>(supplement, out var character))
            {
                assignments.Add(GetIndexAssignment(property, supplement, character.Index));
            }
            else if (property.TryAttribute<TRecord, FieldAttribute>(supplement, out var field))
            {
                assignments.Add(GetRangeAssignment(property, supplement, field.Range));
            }
        }
        Assignments = [.. assignments];
    }

    internal Assignment<TRecord>[] Assignments { get; }
}
