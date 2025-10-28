using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

internal abstract class BaseTarget(INamedTypeSymbol symbol)
{
    protected (Member[], string) GetMembersWithBlank(Member[] members)
    {
        string blank;

        Member[] result;

        var blankMember = members.FirstOrDefault(x => x.IsBlank);

        if (blankMember is not null)
        {
            (blank, _) = blankMember;
            result = [.. members.Except([blankMember])];
        }
        else
        {
            blank = Constants.Unknown;
            result = members;
        }
        return (result, blank);
    }

    internal INamedTypeSymbol Symbol { get; } = symbol;
}

internal class Target(INamedTypeSymbol symbol, Member[] members)
    : BaseTarget(symbol)
{
    private readonly Member[] members = members;

    internal (Member[], string) GetMembersWithBlank() => GetMembersWithBlank(members);
}

internal class OffsetTarget(INamedTypeSymbol symbol, Member[][] offsetMembers)
    : BaseTarget(symbol)
{
    private readonly Member[][] offsetMembers = offsetMembers;

    internal (Member[], string)[] GetMembersWithBlank()
    {
        var result = new (Member[], string)[offsetMembers.Length];

        for (int i = 0; i < offsetMembers.Length; i++)
            result[i] = GetMembersWithBlank(offsetMembers[i]);

        return result;
    }
}
