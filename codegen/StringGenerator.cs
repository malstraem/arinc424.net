using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class StringGenerator : ConverterGenerator
{
    private protected override string GetOffset(string blank) => $" => {String}.IsWhiteSpace() ? {blank} : {String}";

    private protected override StringBuilder WriteMembers(StringBuilder builder, Member[] members, string _)
        => builder.WriteMembers(members).Append($"\n        _ => $\"Substring '{{{String}}}' is not valid.\"");

    private protected override bool IsMatch(EnumDeclarationSyntax @enum) => !@enum.HaveAttribute(FlagsAttribute);

    public StringGenerator()
    {
        @base = StringConverter;
        args = StringArgs;
        qualifier = StringAttributeQualifier;
    }
}
