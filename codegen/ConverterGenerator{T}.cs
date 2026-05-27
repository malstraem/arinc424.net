using System.Collections.Immutable;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arinc424.Generators;

internal abstract class ConverterGenerator<T> : IIncrementalGenerator
    where T : BaseTarget
{
#pragma warning disable CS8618
    protected string @base, qualifier;
#pragma warning restore CS8618
    private void Process(SourceProductionContext context, ImmutableArray<T> targets)
    {
        foreach (var target in targets)
        {
            var (name, text) = Generate(target);

            context.AddSource(name, SourceText.From(text, Encoding.UTF8));
        }
    }

    private (string name, string text) Generate(T target)
    {
        var symbol = target.Symbol;

        string name = $"{symbol.Name}Converter";

        var builder = new StringBuilder().Append($$"""
            using {{symbol.ContainingNamespace}};

            namespace Arinc424.Converters;

            using static {{symbol.Name}};

            internal abstract class {{name}} : {{@base}}<{{symbol.Name}}>
            {
            """);

        return ($"{name}.gen.cs", WriteTarget(builder, target).Append("\n}").ToString());
    }

    protected abstract bool IsMatch(EnumDeclarationSyntax @enum);

    private protected abstract T CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _);

    private protected abstract StringBuilder WriteTarget(StringBuilder builder, T target);

    private IncrementalValueProvider<ImmutableArray<T>> CreateProvider(IncrementalGeneratorInitializationContext incrementalContext)
        => incrementalContext.SyntaxProvider
            .ForAttributeWithMetadataName(
                qualifier,
                (node, _) => node is EnumDeclarationSyntax @enum && IsMatch(@enum),
                CreateTarget
            ).Collect();

    public void Initialize(IncrementalGeneratorInitializationContext context) => context.RegisterSourceOutput(CreateProvider(context), Process);
}
