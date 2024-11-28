using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class CharGenerator : ConverterGenerator
{
    private protected override StringBuilder WriteTarget(StringBuilder builder, BaseTarget target)
    {
        var (members, blank) = ((Target)target).GetMembersWithBlank();

        _ = builder.Append($@"
    public static bool TryConvert({CharArg}, out {target.Symbol.Name} value)
    {{
        switch ({Char})
        {{
            case (char)32:
                value = {blank}; return true;");

        foreach (var member in members)
        {
            var (name, argument) = member;

            _ = builder.Append($@"
            case {argument}:
                value = {name}; return true;");
        }
        return builder.Append(@$"
            default:
                value = {target.Unknown}; return false;
        }}").Append(@"
    }");
    }

    private protected override bool IsMatch(EnumDeclarationSyntax @enum) => @enum.HaveAttribute(CharAttribute);

    public CharGenerator()
    {
        @base = CharConverter;
        qualifier = CharAttributeQualifier;
    }
}
