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

    internal static void Map(this EnumMemberDeclarationSyntax syntax, Queue<Member> members, Queue<Operand> operands)
    {
        var attributes = syntax.AttributeLists.SelectMany(x => x.Attributes)
                                .Where(x => x.Name.ToString() == Constants.SumAttribute).ToArray();

        if (TryMap(syntax, out var member))
        {
            members.Enqueue(member!);

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
        }
        else
        {
            if (attributes.Length == 0)
                return;

            foreach (var attribute in attributes)
            {
                var args = attribute.ArgumentList!.Arguments;

                members.Enqueue(new
                (
                    $"{syntax.Identifier} | {args.First()}",
                    args.Last().ToString()
                ));
            }
        }
    }
}
