using System.Text;

using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

using static Constants;

[Generator]
public class FlagsGenerator : ConverterGenerator
{
    private protected override StringBuilder WriteTarget(StringBuilder builder, BaseTarget target)
    {
        _ = builder.Append($@"
    public static Result<{target.Symbol.Name}> Convert({StringArg})
    {{
        bool valid = true;

        var value = {target.Unknown};").Append("\n");

        var offsetMembers = ((FlagsTarget)target).GetMembersWithBlank();

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
        qualifier = StringAttributeQualifier;
    }
}
