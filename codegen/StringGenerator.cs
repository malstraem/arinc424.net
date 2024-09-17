using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class StringGenerator : ConverterGenerator
{
    private protected override StringBuilder WriteTarget(StringBuilder builder, BaseTarget target)
    {
        var (members, blank) = ((Target)target).GetMembersWithBlank();

        _ = builder.Append($@"
    public static Result<{target.Symbol.Name}> Convert({StringArg}) => {String}.IsWhiteSpace() ? {blank} : {String} switch
    {{");

        foreach (var (name, argument) in members)
        {
            _ = builder.Append($@"
        {argument} => {name},");
        }
        return builder.Append($@"
        _ => {String}
    }};");
    }

    private protected override bool IsMatch(EnumDeclarationSyntax @enum) => !@enum.HaveAttribute(FlagsAttribute);

    public StringGenerator()
    {
        @base = StringConverter;
        qualifier = StringAttributeQualifier;
    }
}
