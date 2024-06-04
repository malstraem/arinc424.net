using System.Reflection;

namespace Arinc424.Building;

internal class BuildInfo<TRecord> where TRecord : Record424
{
    internal BuildInfo(Type type, PropertyInfo[] properties)
    {
        List<IndexAssignmentInfo<TRecord>> indexInfo = [];
        List<RangeAssignmentInfo<TRecord>> rangeInfo = [];
        //List<ArrayAssignmentInfo> arrayInfo = [];

        foreach (var property in properties)
        {
            var regex = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

            if (property.TryCharacterAttribute(type, out var characterAttribute))
            {
                // prefer transform attached to the property
                var transform = property.GetCustomAttribute<TransformAttribute>() ?? property.PropertyType.GetCustomAttribute<TransformAttribute>();

                var assignmentType = typeof(IndexAssignmentInfo<,>).MakeGenericType(type, property.PropertyType);

                object info = Activator.CreateInstance(assignmentType, property, regex, characterAttribute.Index, transform)!;

                indexInfo.Add((IndexAssignmentInfo<TRecord>)info);
                continue;
            }
            else if (property.TryFieldAttribute(type, out var fieldAttribute))
            {
                // prefer decode attached to the property
                var decode = property.GetCustomAttribute<DecodeAttribute>();

                // look inside Nullable <T> if that's the case
                decode ??= property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                        ? property.PropertyType.GetGenericArguments().First().GetCustomAttribute<DecodeAttribute>()
                        : property.PropertyType.GetCustomAttribute<DecodeAttribute>();

                var count = property.GetCustomAttribute<CountAttribute>();

                RangeAssignmentInfo<TRecord> assignment;

                if (count is not null)
                {
                    assignment = new ArrayAssignmentInfo<TRecord>(property, regex, fieldAttribute.Range, count);
                }
                else
                {
                    if (decode is not null)
                    {
                        // look inside Nullable <T> if that's the case
                        var propType = property.PropertyType.IsGenericType && property.PropertyType.GetGenericTypeDefinition() == typeof(Nullable<>)
                                ? property.PropertyType.GetGenericArguments().First()
                                : property.PropertyType;

                        var actionType = typeof(Action<,>).MakeGenericType(type, property.PropertyType);

                        //var action = property.GetSetMethod()!.CreateDelegate(actionType);

                        var assType = typeof(DecodeAssignmentInfo<,>).MakeGenericType(type, propType);

                        assignment = (RangeAssignmentInfo<TRecord>)
                            Activator.CreateInstance(assType, property, regex, fieldAttribute.Range, decode)!;
                    }
                    else
                    {
                        assignment = (RangeAssignmentInfo<TRecord>)
                            Activator.CreateInstance(typeof(StringAssignmentInfo<>)
                                .MakeGenericType(type), property, regex, fieldAttribute.Range)!;
                    }
                }
                rangeInfo.Add(assignment);
                continue;
            }
        }
        IndexInfo = [.. indexInfo];
        RangeInfo = [.. rangeInfo];
    }

    internal IndexAssignmentInfo<TRecord>[] IndexInfo { get; }

    internal RangeAssignmentInfo<TRecord>[] RangeInfo { get; }
}
