using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

internal abstract class InfoAttribute(Type type, PropertyInfo[] properties) : RelationAttribute(type, properties)
{
    internal readonly PrimaryKey? PrimaryKey = PrimaryKey.Create(properties);

    internal readonly SectionAttribute Section = type.GetCustomAttribute<SectionAttribute>()!;

    internal readonly int? ContinuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;
}
