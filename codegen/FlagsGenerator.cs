using System.Text;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class FlagsGenerator : ConverterGenerator
{
    private protected override string GetOffset(string blank) => $"\n{{";

    private protected override StringBuilder WriteMembers(StringBuilder builder, Member[] members, string unknown) => throw new NotImplementedException();

    private protected override StringBuilder WriteTarget(StringBuilder builder, BaseTarget target)
    {
        _ = builder.Append($@"
    {{
        string? problem = null;

        var value = {target.Unknown};").Append("\n");

        var offsetMembers = ((FlagsTarget)target).GetMembersWithBlank();

        for (int i = 0; i < offsetMembers.Length; i++)
        {
            _ = builder.Append(@$"
            char {Char}{i} = {String}[{i}];");
        }
        _ = builder.Append("\n");

        for (int i = 0; i < offsetMembers.Length; i++)
        {
            _ = builder.Append(@$"
        switch ({Char}{i})
        {{");

            var (members, blank) = offsetMembers[i];

            foreach (var member in members)
            {
                var (fullName, argument) = member;

                _ = builder.Append($@"
            case {argument}:
                value |= {fullName}; break;");
            }
            _ = builder.Append(@$"
            default:
                problem += $""Character '{{{Char}{i}}}' is not valid. ""; break;
        }}");
        }
        return builder.Append($@"
        return problem is null ? value : problem.TrimEnd();
    }}
}}
");
    }

    private protected override BaseTarget CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var enumSyntax = (EnumDeclarationSyntax)context.TargetNode;

        var symbol = (INamedTypeSymbol)context.TargetSymbol;

        List<Member> members = [];
        List<Member[]> offsetMembers = [];

        foreach (var member in enumSyntax.Members)
        {
            if (member.HaveAttribute(OffsetAttribute))
            {
                offsetMembers.Add([.. members]);
                members = [];
            }

            if (member.TryAttribute(MapAttribute, out var attribute))
                members.Add(new($"{symbol.Name}.{member.Identifier}", attribute!.ArgumentList?.Arguments.First().ToString() ?? string.Empty));
        }
        offsetMembers.Add([.. members]);

        return new FlagsTarget((INamedTypeSymbol)context.TargetSymbol, [.. offsetMembers]);
    }

    private protected override bool IsMatch(EnumDeclarationSyntax @enum) => @enum.HaveAttribute(FlagsAttribute);

    public FlagsGenerator()
    {
        @base = StringConverter;
        args = StringArgs;
        qualifier = StringAttributeQualifier;
    }
}
