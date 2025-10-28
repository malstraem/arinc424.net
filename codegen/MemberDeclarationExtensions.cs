using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

internal static class MemberDeclarationExtensions
{
    internal static bool HaveAttribute(this MemberDeclarationSyntax member, string name)
        => member.AttributeLists.Any(x => x.Attributes.Any(x => x.Name.ToString() == name));

    internal static bool TryMap(this EnumMemberDeclarationSyntax syntax, out Member? member)
    {
        var attribute = syntax.AttributeLists.SelectMany(x => x.Attributes)
                                         .FirstOrDefault(x => x.Name.ToString() == Constants.MapAttribute);
        if (attribute is null)
        {
            member = null;
            return false;
        }
        member = new
        (
            $"{syntax.Identifier}",
            attribute!.ArgumentList?.Arguments.First().ToString() ?? string.Empty
        );
        return true;
    }

    internal static bool TryMap(this EnumMemberDeclarationSyntax syntax, Queue<Operand> operands, out Member? member)
    {
        if (!TryMap(syntax, out member))
            return false;

        var attributes = syntax.AttributeLists.SelectMany(x => x.Attributes)
                                              .Where(x => x.Name.ToString() == Constants.SumAttribute);
        foreach (var attribute in attributes)
        {
            var args = attribute.ArgumentList!.Arguments;

            operands.Enqueue(new
            (
                args.First().ToString(),
                args.Last().ToString()
            ));
        }

        if (operands.Count > 0)
        {
            member!.Operands = [.. operands];
            operands.Clear();
        }
        return true;
    }
}
