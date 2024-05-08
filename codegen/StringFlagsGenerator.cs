using System.Collections.Immutable;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arinc424.Generators;

[Generator]
public class StringFlagsGenerator : IIncrementalGenerator
{
    private sealed class Target(INamedTypeSymbol symbol, (string, string)[][] members)
    {
        public (string, string)[][] Members = members;

        public INamedTypeSymbol Symbol = symbol;
    }

    private const string MapAttributeName = "Map";
    private const string FlagsAttributeName = "Flags";
    private const string OffsetAttributeName = "Offset";
    private const string AttributeName = "Arinc424.Attributes.StringAttribute";

    private static void WriteMembers(StringBuilder builder, INamedTypeSymbol symbol, (string, string)[][] offsetMembers)
    {
        int index = 0;

        foreach (var members in offsetMembers)
        {
            _ = builder.Append($@"
    | @string[{index}] switch
    {{");
            foreach (var (member, value) in members)
            {
                _ = builder.Append($@"
        {value} => {symbol.Name}.{member},");
            }
            _ = builder.Append($@"
        _ => {symbol.Name}.Unknown");

            index++;
        }
    }

    private static (string, string) Generate(Target target)
    {
        var symbol = target.Symbol;

        var builder = new StringBuilder().Append($@"using {symbol.ContainingNamespace};

namespace Arinc424.Converters;

internal abstract class {symbol.Name}Converter : IStringConverter<{symbol.Name}Converter, {symbol.Name}>
{{
    public static {symbol.Name} Convert(ReadOnlySpan<char> @string)");
        WriteMembers(builder, symbol, target.Members);
        _ = builder.Append($@"
    }};
}}").Append("\n");

        return ($"converters/{symbol.Name}Converter.gen.cs", builder.ToString());
    }

    private void Process(SourceProductionContext context, ImmutableArray<Target> targets)
    {
        foreach (var target in targets)
        {
            var (name, text) = Generate(target);

            //context.AddSource(name, SourceText.From(text, Encoding.UTF8));
        }
    }

    private static bool HaveAttribute(MemberDeclarationSyntax member, string attributeName) =>
        member.AttributeLists.Any(x => x.Attributes.Any(x => x.Name.ToString() == attributeName));

    private static bool TryAttribute(MemberDeclarationSyntax member, string attributeName, out AttributeSyntax? attribute)
    {
        attribute = member.AttributeLists.SelectMany(x => x.Attributes).FirstOrDefault(x => x.Name.ToString() == attributeName);

        return attribute is not null;
    }

    private static IncrementalValueProvider<ImmutableArray<Target>> CreateProvider(IncrementalGeneratorInitializationContext context)
    {
        return context.SyntaxProvider.ForAttributeWithMetadataName
        (
            AttributeName,
            (node, _) => node is EnumDeclarationSyntax @enum && HaveAttribute(@enum, FlagsAttributeName),
            (context, _) =>
            {
                var enumSyntax = (EnumDeclarationSyntax)context.TargetNode;

                List<(string, string)> members = [];
                List<(string, string)[]> offsetMembers = [];

                foreach (var member in enumSyntax.Members)
                {
                    if (HaveAttribute(member, OffsetAttributeName))
                    {
                        offsetMembers.Add([.. members]);
                        members = [];
                    }

                    if (TryAttribute(member, MapAttributeName, out var attribute))
                        members.Add((member.Identifier.ToString(), attribute.ArgumentList!.Arguments.First().ToString()));
                }
                offsetMembers.Add([.. members]);

                return new Target((INamedTypeSymbol)context.TargetSymbol, [.. offsetMembers]);
            }
        ).Collect();
    }

    public void Initialize(IncrementalGeneratorInitializationContext context) => context.RegisterSourceOutput(CreateProvider(context), Process);
}
