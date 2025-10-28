using System.Text;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

using static Constants;

[Generator]
internal class StringFlagsGenerator : StringGenerator<OffsetTarget>
{
    private protected override StringBuilder WriteTarget(StringBuilder builder, OffsetTarget target)
    {
        _ = builder.Append($@"
    public static Result<{target.Symbol.Name}> Convert({StringArg})
    {{
        bool valid = true;

        var value = {Unknown};").Append("\n");

        var offsetMembers = target.GetMembersWithBlank();

        string[] charDeclarations = new string[offsetMembers.Length];

        for (int i = 0; i < offsetMembers.Length; i++)
            charDeclarations[i] = $"{Char}{i} = {String}[{i}]";

        _ = builder.Append($@"
        char {string.Join(", ", charDeclarations)};").Append("\n");

        for (int i = 0; i < offsetMembers.Length; i++)
        {
            _ = builder.Append(@$"
        switch ({Char}{i})
        {{");

            var (members, blank) = offsetMembers[i];

            _ = builder.Append(@$"
            case (char)32:
                value |= {blank}; break;");

            foreach (var member in members)
            {
                var (fullName, argument) = member;

                _ = builder.Append($@"
            case {argument}:
                value |= {fullName}; break;");
            }
            _ = builder.Append(@$"
            default:
                valid = false; break;
        }}");
        }
        return builder.Append($@"
        return valid ? value : {String};
    }}");
    }

    private protected override OffsetTarget CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var @enum = (EnumDeclarationSyntax)context.TargetNode;

        Queue<Member> members = [];
        Queue<Member[]> offsetMembers = [];

        foreach (var member in @enum.Members)
        {
            if (member.HaveAttribute(OffsetAttribute))
            {
                offsetMembers.Enqueue([.. members]);
                members = [];
            }

            if (member.TryMap(out var map))
                members.Enqueue(map!);
        }
        offsetMembers.Enqueue([.. members]);

        return new OffsetTarget((INamedTypeSymbol)context.TargetSymbol, [.. offsetMembers]);
    }

    protected override bool IsMatch(EnumDeclarationSyntax @enum)
        => @enum.HaveAttribute(StringAttribute) && @enum.HaveAttribute(FlagsAttribute);
}
