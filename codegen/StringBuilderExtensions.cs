using System.Text;

namespace Arinc424.Generators;

internal static class StringBuilderExtensions
{
    internal static StringBuilder WriteOffset(this StringBuilder builder, string offset) => builder.Append($"{offset} switch\n    {{");

    internal static StringBuilder WriteMembers(this StringBuilder builder, Member[] members, string unknown)
    {
        foreach (var (member, argument) in members)
            _ = builder.Append($"\n        {argument} => {member},");

        return builder.Append($"\n        _ => {unknown}");
    }
}
