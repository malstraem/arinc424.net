using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Arinc424.Generators;

internal static class MemberDeclarationSyntaxExtensions
{
    internal static bool HaveAttribute(this MemberDeclarationSyntax member, string attributeName)
        => member.AttributeLists.Any(x => x.Attributes.Any(x => x.Name.ToString() == attributeName));

    internal static bool TryAttribute(this MemberDeclarationSyntax member, string attributeName, out AttributeSyntax? attribute)
    {
        attribute = member.AttributeLists.SelectMany(x => x.Attributes).FirstOrDefault(x => x.Name.ToString() == attributeName);
        return attribute is not null;
    }
}
