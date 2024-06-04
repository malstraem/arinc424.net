using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

#pragma warning disable CA1018

internal class LinksAttribute : Attribute
{
    internal LinksAttribute(Type type, PropertyInfo[] properties)
    {
        Type = type;

        List<Link> links = [];

        Dictionary<Type, PropertyInfo> one = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in properties)
        {
            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
            {
                links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
                continue;
            }

            if (property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                many.Add(property.PropertyType.GetGenericArguments().First(), property);
            }
            else if (property.GetCustomAttribute<OneAttribute>() is not null)
            {
                one.Add(property.PropertyType, property);
            }
        }

        if (links.Count > 0)
            Links = [.. links];

        if (one.Count > 0)
            One = one;

        if (many.Count > 0)
            Many = many;
    }

    internal Type Type { get; }

    internal Link[]? Links { get; }

    internal Dictionary<Type, PropertyInfo>? One { get; }

    internal Dictionary<Type, PropertyInfo>? Many { get; }
}
