using System.Reflection;
using System.Text.RegularExpressions;

namespace Arinc424.Building;

internal class BuildInfo<TRecord> where TRecord : Record424
{
    private static IndexAssignment<TRecord> GetIndexAssignment(PropertyInfo property, Regex? regex, int index)
    {
        // prefer transform attached to the property
        var transform = property.GetCustomAttribute<TransformAttribute>() ?? property.PropertyType.GetCustomAttribute<TransformAttribute>();

        return transform is not null
            ? (IndexAssignment<TRecord>)
                Activator.CreateInstance(typeof(TransformAssignment<,>)
                    .MakeGenericType(typeof(TRecord), property.PropertyType), property, regex, index, transform)!

            : new CharAssignment<TRecord>(property, regex, index)!;
    }

    private static RangeAssignment<TRecord> GetRangeAssignment(PropertyInfo property, Regex? regex, Range range)
    {
        var (type, isValueNullable) = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
            ? (property.PropertyType.GetGenericArguments().First(), true) // look inside Nullable<T> if that's the case
            : (property.PropertyType, false);

        // prefer decode attached to the property
        var decode = property.GetCustomAttribute<DecodeAttribute>() ?? (type.IsArray
            ? type.GetElementType()!.GetCustomAttribute<DecodeAttribute>()
            : type.GetCustomAttribute<DecodeAttribute>());

        return decode is not null
            ? type.IsArray
                ? (RangeAssignment<TRecord>)
                    Activator.CreateInstance(typeof(ArrayAssignment<,>)
                        .MakeGenericType(typeof(TRecord), type.GetElementType()!), property, regex, range, decode, property.GetCustomAttribute<CountAttribute>()!.Count)!

                : (RangeAssignment<TRecord>)
                    Activator.CreateInstance(typeof(DecodeAssignment<,>)
                        .MakeGenericType(typeof(TRecord), type), property, regex, range, decode, isValueNullable)!

            : new StringAssignment<TRecord>(property, regex, range);
    }

    internal BuildInfo(Type type, PropertyInfo[] properties)
    {
        List<Assignment<TRecord>> assignments = [];

        foreach (var property in properties)
        {
            var regex = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

            if (property.TryCharacterAttribute(type, out var characterAttribute))
            {
                assignments.Add(GetIndexAssignment(property, regex, characterAttribute.Index));
            }
            else if (property.TryFieldAttribute(type, out var fieldAttribute))
            {
                assignments.Add(GetRangeAssignment(property, regex, fieldAttribute.Range));
            }
        }
        Assignments = [.. assignments];
    }

    internal Assignment<TRecord>[] Assignments { get; }
}
