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
        List<ArrayAssignmentInfo> arrayInfo = [];

        List<Link> links = [];

        Dictionary<Type, PropertyInfo> one = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in properties)
        {
            var regex = property.GetCustomAttribute<ValidationAttribute>()?.Regex;

            if (property.TryCharacterAttribute(type, out var characterAttribute))
            {
                indexInfo.Add(new IndexAssignmentInfo(property, regex, characterAttribute!.Index, property.GetCustomAttribute<TransformAttribute>()));
                continue;
            }
            else if (property.TryFieldAttribute(type, out var fieldAttribute))
            {
                var arrayAttribute = property.GetCustomAttribute<CountAttributeAttribute>();

                if (arrayAttribute is not null)
                    arrayInfo.Add(new ArrayAssignmentInfo(property, regex, fieldAttribute!.Range, arrayAttribute));
                else
                    rangeInfo.Add(new RangeAssignmentInfo(property, regex, fieldAttribute!.Range, property.GetCustomAttribute<DecodeAttribute>()));

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
        ArrayInfo = [.. arrayInfo];

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

    internal ArrayAssignmentInfo[] ArrayInfo { get; }

    internal Link[]? Links { get; }

    internal Dictionary<Type, PropertyInfo>? One { get; }

    internal Dictionary<Type, PropertyInfo>? Many { get; }
}
