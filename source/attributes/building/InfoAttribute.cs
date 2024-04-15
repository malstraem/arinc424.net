using System.Reflection;

using Arinc424.Relations;

namespace Arinc424.Attributes;

internal abstract class InfoAttribute : Attribute
{
    internal readonly Type Type;

    internal readonly SectionAttribute Section;

    internal readonly List<Link> Links = [];

    internal readonly List<Range> PrimaryRanges = [];

    internal readonly Dictionary<Type, PropertyInfo> Many = [];

    internal readonly int KeyLength;

    internal readonly int? ContinuationIndex;

    private void FillRelationsInfo(Type type)
    {
        var properties = type.GetProperties();

        foreach (var property in properties)
        {
            if (property.GetCustomAttribute<PrimaryAttribute>() is not null)
            {
                var fieldAttribute = property.GetCustomAttribute<FieldAttribute>();

                if (fieldAttribute is not null)
                {
                    PrimaryRanges.Add(fieldAttribute.Range);
                }
                else
                {
                    var foreignAttribute = property.GetCustomAttribute<ForeignAttribute>();

                    if (foreignAttribute is not null)
                        PrimaryRanges.Add(foreignAttribute.Range);
                }
            }

            if (property.GetCustomAttribute<ManyAttribute>() is not null)
                Many.Add(property.PropertyType.GetGenericArguments().First(), property);

            var foreignAttributes = property.GetCustomAttributes<ForeignAttribute>();

            if (foreignAttributes.Any())
                Links.Add(new Link(property, foreignAttributes.ToArray(), property.GetCustomAttribute<TypeAttribute>()));
        }
    }

    internal InfoAttribute(Type type)
    {
        Type = type;

        Section = type.GetCustomAttribute<SectionAttribute>()!;
        ContinuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

        FillRelationsInfo(type);

        foreach (var range in PrimaryRanges)
        {
            var (_, length) = range.GetOffsetAndLength(132);
            KeyLength += length;
        }
    }

    internal string GetPrimaryKey(Record424 record)
    {
        int index = 0;

        char[] key = new char[KeyLength];

        foreach (var range in PrimaryRanges)
        {
            var (offset, length) = range.GetOffsetAndLength(132);

            for (int i = offset; i < offset + length; i++)
                key[index++] = record.Source[i];
        }
        return new string(key);
    }

    internal List<Reference> GetReferences(Record424 record)
    {
        List<Reference> references = [];

        foreach (var link in Links)
        {
            if (link.TryGetReference(record.Source, out var reference))
                references.Add(reference!);
        }
        return references;
    }

    internal bool HasKey => PrimaryRanges.Count > 0;

    internal bool HasLinks => Links.Count > 0;
}
