using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
internal class CharGenerator : ConverterGenerator<Target>
{
    private protected override StringBuilder WriteTarget(StringBuilder builder, Target target)
    {
        var (members, blank) = target.GetMembersWithBlank();

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
                value = {Unknown}; return false;
        }}").Append(@"
    }");
    }

    protected override bool IsMatch(EnumDeclarationSyntax @enum)
        => @enum.HaveAttribute(CharAttribute) && !@enum.HaveAttribute(FlagsAttribute);

    private protected override Target CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var @enum = (EnumDeclarationSyntax)context.TargetNode;

        Queue<Member> members = [];

        foreach (var member in @enum.Members)
        {
            if (member.TryMap(out var map))
                members.Enqueue(map!);
        }
        return new Target((INamedTypeSymbol)context.TargetSymbol, [.. members]);
    }

    public CharGenerator()
    {
        @base = CharConverter;
        qualifier = CharAttributeQualifier;
    }
}
