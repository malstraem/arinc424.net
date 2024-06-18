using System.Reflection;

namespace Arinc424.Attributes;

internal abstract class InfoAttribute(Type type) : LinksAttribute(type)
{
    private readonly int? continuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

    internal SectionAttribute Section { get; } = type.GetCustomAttribute<SectionAttribute>()!;

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';
}
