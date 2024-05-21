using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

internal abstract class InfoAttribute(Type type, PropertyInfo[] properties) : BuildAttribute(type, properties)
{
    internal PrimaryKey? PrimaryKey { get; } = PrimaryKey.Create(properties);

    internal SectionAttribute Section { get; } = type.GetCustomAttribute<SectionAttribute>()!;

    internal int? ContinuationIndex { get; } = type.GetCustomAttribute<ContinuousAttribute>()?.Index;
}
