using System.Reflection;

using Arinc424.Building;

namespace Arinc424.Attributes;

internal abstract class BuildAttribute(Type type) : LinksAttribute(type)
{
    private readonly SectionAttribute section = type.GetCustomAttribute<SectionAttribute>()!;

    private readonly int? continuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';

    internal (char, char) Section => (section.Section, section.Subsection);
}
