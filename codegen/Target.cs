using Microsoft.CodeAnalysis;

namespace Arinc424.Generators;

internal class Target(INamedTypeSymbol symbol, Member[][] members, bool isChar, bool isFlags)
{
    internal readonly Member[][] Members = members;

    internal readonly INamedTypeSymbol Symbol = symbol;

    internal readonly string Unknown = $"{symbol.Name}.Unknown";

    internal readonly bool IsChar = isChar;

    internal readonly bool IsFlags = isFlags;
}
