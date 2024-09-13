using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class CharGenerator : ConverterGenerator
{
    private protected override string GetOffset(string blank) => $" => char.IsWhiteSpace({Char}) ? {blank} : {Char}";

    private protected override StringBuilder WriteMembers(StringBuilder builder, Member[] members, string _)
        => builder.WriteMembers(members).Append($"\n        _ => {Char}");

    private protected override bool IsMatch(EnumDeclarationSyntax @enum) => @enum.HaveAttribute(CharAttribute);

    public CharGenerator()
    {
        @base = CharConverter;
        args = CharArgs;
        qualifier = CharAttributeQualifier;
    }
}
