using System.Text;

using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class CharGenerator() : ConverterGenerator(Constants.CharAttribute)
{
    internal override StringBuilder WriteMembers(StringBuilder builder, Member[] members, string unknown)
        => builder.WriteMembers(members).Append($"\n        _ => $\"Char '{{{Char}}}' is not valid.\"");
}
