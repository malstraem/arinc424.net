using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

internal class InfoAttribute : Attribute
{
    internal readonly Type Type;

    internal readonly PrimaryKey? PrimaryKey;

    internal readonly SectionAttribute Section;

    internal readonly List<Link>? Links;

    internal readonly Dictionary<Type, PropertyInfo>? Many;

    internal readonly int? ContinuationIndex;

    internal InfoAttribute(Type type)
    {
        Type = type;

        Section = type.GetCustomAttribute<SectionAttribute>()!;
        ContinuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

        var properties = type.GetProperties();

        _ = PrimaryKey.TryCreate(properties, out PrimaryKey);

        List<Link> links = [];
        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<ManyAttribute>() is not null)
                many.Add(property.PropertyType.GetGenericArguments().First(), property);

            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
                links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
        }

        if (links.Count > 0)
            Links = links;

        if (many.Count > 0)
            Many = many;
    }

    internal List<Reference> GetReferences(Record424 record)
    {
        List<Reference> references = [];

        foreach (var link in Links!)
        {
            if (link.TryGetReference(record.Source, out var reference))
                references.Add(reference!);
        }
        return references;
    }
}
