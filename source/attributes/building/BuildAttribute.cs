using System.Reflection;

using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424.Attributes;

#pragma warning disable CA1018

internal class BuildAttribute : Attribute
{
    internal BuildAttribute(Type type, PropertyInfo[] properties)
    {
        Type = type;

        List<IndexAssignmentInfo> indexInfo = [];
        List<RangeAssignmentInfo> rangeInfo = [];

        List<Link> links = [];

        Dictionary<Type, PropertyInfo> one = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in properties)
        {
            var regex = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

            if (property.TryCharacterAttribute(type, out var characterAttribute))
            {
                // prefer transform attached to the property
                var transform = property.GetCustomAttribute<TransformAttribute>() ?? property.PropertyType.GetCustomAttribute<TransformAttribute>();
                indexInfo.Add(new IndexAssignmentInfo(property, regex, characterAttribute.Index, transform));
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

                var assignment = count is not null
                    ? new ArrayAssignmentInfo(property, regex, fieldAttribute.Range, count)
                    : new RangeAssignmentInfo(property, regex, fieldAttribute.Range, decode);

                rangeInfo.Add(assignment);
                continue;
            }

            if (property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                many.Add(property.PropertyType.GetGenericArguments().First(), property);
                continue;
            }
            else if (property.GetCustomAttribute<OneAttribute>() is not null)
            {
                one.Add(property.PropertyType, property);
                continue;
            }

            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
                links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
        }

        IndexInfo = [.. indexInfo];
        RangeInfo = [.. rangeInfo];

        if (links.Count > 0)
            Links = [.. links];

        if (one.Count > 0)
            One = one;

        if (many.Count > 0)
            Many = many;
    }

    internal Type Type { get; }

    internal IndexAssignmentInfo[] IndexInfo { get; }

    internal RangeAssignmentInfo[] RangeInfo { get; }

    internal Link[]? Links { get; }

    internal Dictionary<Type, PropertyInfo>? One { get; }

    internal Dictionary<Type, PropertyInfo>? Many { get; }
}
