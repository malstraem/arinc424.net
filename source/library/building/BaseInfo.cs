namespace Arinc424.Building;

using Linking;

internal class BaseInfo(Type[] composition, SectionAttribute[] sections, Relation[]? relations)
{
    internal Type Top { get; } = composition.Last();

    internal Type Low { get; } = composition.First();

    internal Type[] Composition { get; } = composition;

    internal Relation[]? Relations { get; } = relations;

    internal SectionAttribute[] Sections { get; } = sections;
}
