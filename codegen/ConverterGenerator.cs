using System.Collections.Immutable;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arinc424.Generators;

[Generator]
public class ConverterGenerator : IIncrementalGenerator
{
    private sealed class Target(INamedTypeSymbol symbol, (string, string)[] members)
    {
        public (string, string)[] Members = members;

        public INamedTypeSymbol Symbol = symbol;
    }

    private const string MapAttributeName = "Map";
    private const string CharAttributeName = "Arinc424.Attributes.CharAttribute";

    private static (string, string) Generate(Target target)
    {
        var symbol = target.Symbol;

        var builder = new StringBuilder().Append($@"using {symbol.ContainingNamespace};

namespace Arinc424.Converters;

internal abstract class {symbol.Name}Converter : ICharConverter<{symbol.Name}Converter, {symbol.Name}>
{{
    public static {symbol.Name} Convert(char @char) => @char switch
    {{");
        foreach (var (member, value) in target.Members)
        {
            _ = builder.Append($@"
        {value} => {symbol.Name}.{member},");
        }
        _ = builder.Append($@"
        _ => {symbol.Name}.Unknown
    }};
}}").Append("\n");

        return ($"{symbol.Name}Converter.gen.cs", builder.ToString());
    }

    private void Process(SourceProductionContext context, ImmutableArray<Target> targets)
    {
        foreach (var target in targets)
        {
            var (name, text) = Generate(target);

            context.AddSource(name, SourceText.From(text, Encoding.UTF8));
        }
    }

    private static IncrementalValueProvider<ImmutableArray<Target>> CreateProvider(IncrementalGeneratorInitializationContext context)
    {
        return context.SyntaxProvider.ForAttributeWithMetadataName
        (
            CharAttributeName,
            (node, _) => node is EnumDeclarationSyntax,
            (context, _) =>
            {
                var enumSyntax = (EnumDeclarationSyntax)context.TargetNode;

                var symbol = (INamedTypeSymbol)context.TargetSymbol;

                List<(string, string)> members = [];

                foreach (var member in enumSyntax.Members)
                {
                    foreach (var syntax in member.AttributeLists)
                    {
                        var attribute = syntax.Attributes.FirstOrDefault(x => x.Name.ToString() == MapAttributeName);

                        if (attribute is not null)
                            members.Add((member.Identifier.ToString(), attribute.ArgumentList!.Arguments.First().ToString()));
                    }
                }
                return new Target(symbol, [.. members]);
            }
        ).Collect();
    }

    public void Initialize(IncrementalGeneratorInitializationContext context) => context.RegisterSourceOutput(CreateProvider(context), Process);
}
