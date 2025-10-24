using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

[Generator]
internal class CharFlagsGenerator : CharGenerator
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
            var (name, value) = member;

            _ = builder.Append($@"
            case {value}:
                value = {name}; return true;");

            if (member.Operands is null)
                continue;

            foreach (var operand in member.Operands)
            {
                var (oname, ovalue) = operand;

                _ = builder.Append($@"
            case {ovalue}:
                value = {name} | {oname}; return true;");
            }
        }
        return builder.Append(@$"
            default:
                value = {Unknown}; return false;
        }}").Append(@"
    }");
    }

    private protected override Target CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        Queue<Operand> operands = [];

        var @enum = (EnumDeclarationSyntax)context.TargetNode;

        Queue<Member> members = [];

        foreach (var member in @enum.Members)
        {
            if (member.TryMap(operands, out var map))
                members.Enqueue(map!);
        }
        return new Target((INamedTypeSymbol)context.TargetSymbol, [.. members]);
    }

    protected override bool IsMatch(EnumDeclarationSyntax @enum)
        => @enum.HaveAttribute(CharAttribute) && @enum.HaveAttribute(FlagsAttribute);
}
