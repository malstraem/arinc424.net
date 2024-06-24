using System.Reflection;

namespace Arinc424.Linking;

internal class LinksInfo
{
    internal LinksInfo(Type type)
    {
        List<Link> links = [];

        Dictionary<Type, PropertyInfo> one = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in type.GetProperties())
        {
            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
            {
                links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
            }
            else if (property.GetCustomAttribute<ManyAttribute>() is not null)
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

    internal Link[]? Links { get; }

    internal Dictionary<Type, PropertyInfo>? One { get; }

    internal Dictionary<Type, PropertyInfo>? Many { get; }
}
