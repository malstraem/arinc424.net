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
        var decodes = property.GetCustomAttributes<DecodeAttribute>();

        if (!decodes.Any())
            decodes = type.IsArray ? type.GetElementType()!.GetCustomAttributes<DecodeAttribute>() : type.GetCustomAttributes<DecodeAttribute>();

        var decode = decodes.FirstOrDefault();

        foreach (var attribute in decodes)
        {
            if (attribute.IsMatch<TRecord>())
            {
                decode = attribute;
                break;
            }
        }

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

    internal BuildInfo(Supplement supplement)
    {
        List<Assignment<TRecord>> assignments = [];

        foreach (var property in typeof(TRecord).GetProperties())
        {
            var regex = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

            if (property.TryCharacterAttribute<TRecord>(supplement, out var characterAttribute))
            {
                assignments.Add(GetIndexAssignment(property, regex, characterAttribute.Index));
            }
            else if (property.TryFieldAttribute<TRecord>(supplement, out var fieldAttribute))
            {
                assignments.Add(GetRangeAssignment(property, regex, fieldAttribute.Range));
            }
        }
        Assignments = [.. assignments];
    }

    internal Assignment<TRecord>[] Assignments { get; }
}
