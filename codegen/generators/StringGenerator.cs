using System.Text;

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

using static Constants;

internal abstract class StringGenerator<T> : ConverterGenerator<T>
    where T : BaseTarget
{
    protected override bool IsMatch(EnumDeclarationSyntax @enum)
        => @enum.HaveAttribute(StringAttribute) && !@enum.HaveAttribute(FlagsAttribute);

    public StringGenerator()
    {
        @base = StringConverter;
        qualifier = StringAttributeQualifier;
    }
}

[Generator]
internal class StringGenerator : StringGenerator<Target>
{
    private protected override Target CreateTarget(GeneratorAttributeSyntaxContext context, CancellationToken _)
    {
        var @enum = (EnumDeclarationSyntax)context.TargetNode;

        Queue<Member> members = [];

        foreach (var member in @enum.Members)
        {
            if (member.TryMap(out var map))
                members.Enqueue(map!);
        }
        return new Target((INamedTypeSymbol)context.TargetSymbol, [.. members]);
    }

    private protected override StringBuilder WriteTarget(StringBuilder builder, Target target)
    {
        var (members, blank) = target.GetMembersWithBlank();

        _ = builder.Append($@"
    public static Result<{target.Symbol.Name}> Convert({StringArg})
        => {String}.IsWhiteSpace() ? {blank} : {String} switch
    {{");

        foreach (var (name, argument) in members)
        {
            _ = builder.Append($@"
        {argument} => {name},");
        }
        return builder.Append($@"
        _ => {String}
    }};");
    }
}
