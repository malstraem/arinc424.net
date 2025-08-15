namespace Arinc424.Building;

internal abstract class BaseInfo(Composition composition, SectionAttribute[] sections)
{
    internal Composition Composition { get; } = composition;

    internal SectionAttribute[] Sections { get; } = sections;
}
