using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

#pragma warning disable CA1018

internal class RelationsAttribute(Type type) : Attribute
{
    internal readonly Type Type = type;

    internal readonly Link[]? Links;

    internal readonly Dictionary<Type, PropertyInfo>? One;
    internal readonly Dictionary<Type, PropertyInfo>? Many;

    internal RelationsAttribute(Type type, PropertyInfo[] properties) : this(type)
    {
        List<Link> links = [];

        Dictionary<Type, PropertyInfo> one = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<ManyAttribute>() is not null)
                many.Add(property.PropertyType.GetGenericArguments().First(), property);
            else if (property.GetCustomAttribute<OneAttribute>() is not null)
                one.Add(property.PropertyType, property);

            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
                links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
        }

        if (links.Count > 0)
            Links = [.. links];

        if (one.Count > 0)
            One = one;

        if (many.Count > 0)
            Many = many;
    }
}
