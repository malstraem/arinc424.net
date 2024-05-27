using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Attributes;

internal abstract class InfoAttribute(Type type, PropertyInfo[] properties) : BuildAttribute(type, properties)
{
    private readonly int? continuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

    internal PrimaryKey? PrimaryKey { get; } = PrimaryKey.Create(properties);

    internal SectionAttribute Section { get; } = type.GetCustomAttribute<SectionAttribute>()!;

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';
}
