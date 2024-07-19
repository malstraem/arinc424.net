using System.Collections.Immutable;
using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;

namespace Arinc424.Generators;

using static Constants;

public abstract class ConverterGenerator(string qualifier) : IIncrementalGenerator
{
    internal virtual StringBuilder WriteTarget(StringBuilder builder, Target target)
    {
        var members = target.Members.FirstOrDefault();

        if (members is null)
            return builder;

        string offset = target.IsChar
            ? Char
            : target.IsFlags ? $"{String}[0]" : String;

        var blank = members.FirstOrDefault(x => x.IsBlank);

        if (blank is not null)
        {
            var (member, argument) = blank;

            string check = target.IsChar ? $"char.IsWhiteSpace({Char})" : $"{String}.IsWhiteSpace()";

            _ = builder.Append($"{check} ? {member} : ");

            members = members.Except([blank]).ToArray();
        }

        return builder.WriteOffset(offset).WriteMembers(members, target.Unknown).Append("\n    }");
    }

    private (string name, string text) Generate(Target target)
    {
        var symbol = target.Symbol;

        var (converter, signature, @return) = target.IsChar
            ? (CharConverter, CharSignature, symbol.Name)
            : (StringConverter, StringSignature, $"Result<{symbol.Name}>");

        string name = $"{symbol.Name}Converter";

        var builder = new StringBuilder().Append($@"using {symbol.ContainingNamespace};

namespace Arinc424.Converters;

internal abstract class {name} : {converter}<{symbol.Name}>
{{
    public static {@return} Convert({signature}) => ");

        _ = WriteTarget(builder, target).Append(";\n}\n");

        return ($"{name}.gen.cs", builder.ToString());
    }

    private void Process(SourceProductionContext context, ImmutableArray<Target> targets)
    {
        foreach (var target in targets)
        {
            var (name, text) = Generate(target);

            context.AddSource(name, SourceText.From(text, Encoding.UTF8));
        }
    }

    private static bool HaveAttribute(MemberDeclarationSyntax member, string attributeName) =>
        member.AttributeLists.Any(x => x.Attributes.Any(x => x.Name.ToString() == attributeName));

    private static bool TryAttribute(MemberDeclarationSyntax member, string attributeName, out AttributeSyntax? attribute)
    {
        attribute = member.AttributeLists.SelectMany(x => x.Attributes).FirstOrDefault(x => x.Name.ToString() == attributeName);
        return attribute is not null;
    }

    private IncrementalValueProvider<ImmutableArray<Target>> CreateProvider(IncrementalGeneratorInitializationContext incrementalContext)
    {
        return incrementalContext.SyntaxProvider.ForAttributeWithMetadataName
        (
            qualifier,
            (node, _) => node is EnumDeclarationSyntax,
            (context, _) =>
            {
                var enumSyntax = (EnumDeclarationSyntax)context.TargetNode;

                var symbol = (INamedTypeSymbol)context.TargetSymbol;

                List<Member> members = [];
                List<Member[]> offsetMembers = [];

                foreach (var member in enumSyntax.Members)
                {
                    if (HaveAttribute(member, OffsetAttribute))
                    {
                        offsetMembers.Add([.. members]);
                        members = [];
                    }

                    if (TryAttribute(member, MapAttribute, out var attribute))
                        members.Add(new($"{symbol.Name}.{member.Identifier}", attribute!.ArgumentList?.Arguments.First().ToString() ?? string.Empty));
                }
                offsetMembers.Add([.. members]);

                return new Target((INamedTypeSymbol)context.TargetSymbol, [.. offsetMembers], qualifier == CharAttribute, HaveAttribute(enumSyntax, FlagsAttribute));
            }
        ).Collect();
    }

    public void Initialize(IncrementalGeneratorInitializationContext context) => context.RegisterSourceOutput(CreateProvider(context), Process);
}
