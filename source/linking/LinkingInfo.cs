using System.Reflection;

using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Linking;

internal class LinkingInfo
{
    internal static bool TryCreate(Type type, out LinkingInfo? linkingInfo)
    {
        linkingInfo = null;

        if (type.IsAbstract)
            return false;

        List<Link> links = [];
        List<Range> ranges = [];
        Dictionary<Type, PropertyInfo> many = [];

        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<PrimaryAttribute>() is not null)
            {
                var fieldAttribute = property.GetCustomAttribute<FieldAttribute>();

                if (fieldAttribute is not null)
                {
                    ranges.Add(fieldAttribute.Range);
                }
                else
                {
                    var foreignAttribute = property.GetCustomAttribute<ForeignAttribute>();

                    if (foreignAttribute is not null)
                        ranges.Add(foreignAttribute.Range);
                }
            }

            if (property.GetCustomAttribute<ManyAttribute>() is not null)
                many.Add(property.PropertyType.GetGenericArguments().First(), property);

            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
                links.Add(new Link(property, foreignAttributes, property.GetCustomAttribute<TypeAttribute>()));
        }

        if (links.Count == 0 && ranges.Count == 0)
            return false;

        linkingInfo = new LinkingInfo { Links = links, PrimaryRanges = ranges, Many = many };

        return true;
    }

    internal required List<Link> Links { get; init; }

    internal required List<Range> PrimaryRanges { get; init; }

    internal required Dictionary<Type, PropertyInfo> Many { get; init; }
}
