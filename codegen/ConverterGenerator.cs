using System.Collections.Immutable;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arinc424.Generators;

using static Constants;

public abstract class ConverterGenerator : IIncrementalGenerator
{
#pragma warning disable CS8618
    protected string @base, args, qualifier;
#pragma warning restore CS8618
    private protected abstract string GetOffset(string blank);

    private protected abstract StringBuilder WriteMembers(StringBuilder builder, Member[] members, string unknown);

    private protected virtual StringBuilder WriteTarget(StringBuilder builder, BaseTarget target)
    {
        var (members, blank) = ((Target)target).GetMembersWithBlank();

        return WriteMembers(builder.WriteOffset(GetOffset(blank)), members, target.Unknown).Append("\n    };\n}\n");
    }

    private void Process(SourceProductionContext context, ImmutableArray<BaseTarget> targets)
    {
        foreach (var target in targets)
        {
            var (name, text) = Generate(target);

            context.AddSource(name, SourceText.From(text, Encoding.UTF8));
        }
    }

    private (string name, string text) Generate(BaseTarget target)
    {
        var symbol = target.Symbol;

        string name = $"{symbol.Name}Converter";

        var builder = new StringBuilder().Append($$"""
            using {{symbol.ContainingNamespace}};

            namespace Arinc424.Converters;

            internal abstract class {{name}} : {{@base}}<{{symbol.Name}}>
            {
                public static Result<{{symbol.Name}}> Convert({{args}})
            """);

        return ($"{name}.gen.cs", WriteTarget(builder, target).ToString());
    }

    private protected virtual bool IsMatch(EnumDeclarationSyntax @enum) => true;

    private protected virtual BaseTarget CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var enumSyntax = (EnumDeclarationSyntax)context.TargetNode;

        var symbol = (INamedTypeSymbol)context.TargetSymbol;

        List<Member> members = [];

        foreach (var member in enumSyntax.Members)
        {
            if (member.TryAttribute(MapAttribute, out var attribute))
                members.Add(new($"{symbol.Name}.{member.Identifier}", attribute!.ArgumentList?.Arguments.First().ToString() ?? string.Empty));
        }
        return new Target((INamedTypeSymbol)context.TargetSymbol, [.. members]);
    }

    private IncrementalValueProvider<ImmutableArray<BaseTarget>> CreateProvider(IncrementalGeneratorInitializationContext incrementalContext)
        => incrementalContext.SyntaxProvider
            .ForAttributeWithMetadataName(
                qualifier,
                (node, _) => node is EnumDeclarationSyntax @enum && IsMatch(@enum),
                CreateTarget
            ).Collect();

    public void Initialize(IncrementalGeneratorInitializationContext context) => context.RegisterSourceOutput(CreateProvider(context), Process);
}
