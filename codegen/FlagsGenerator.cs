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
        bool valid = true;

        var value = {target.Unknown};").Append("\n");

        var offsetMembers = ((FlagsTarget)target).GetMembersWithBlank();

        string[] problemVariables = new string[offsetMembers.Length],
                 charDeclarations = new string[offsetMembers.Length],
                 problemDeclarations = new string[offsetMembers.Length];

        for (int i = 0; i < offsetMembers.Length; i++)
        {
            problemVariables[i] = $"{Problem}{i}";
            charDeclarations[i] = $"{Char}{i} = {String}[{i}]";
            problemDeclarations[i] = $"{problemVariables[i]} = null";
        }
        _ = builder.Append($@"
        char {string.Join(", ", charDeclarations)};

        string? {string.Join(", ", problemDeclarations)};").Append("\n");

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
            case (char)32:
                value |= {blank}; break;
            default:
                valid = false;
                {Problem}{i} = $""Character '{{{Char}{i}}}' is not valid.""; break;
        }}");
        }
        return builder.Append($@"
        return valid ? value : string.Join((char)32, {string.Join(", ", problemVariables)});
    }}
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
        args = StringArgs;
        qualifier = StringAttributeQualifier;
    }
}
