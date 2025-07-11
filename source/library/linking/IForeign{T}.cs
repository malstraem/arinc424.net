using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal interface IForeign : IKey
{
    internal bool TryGetKey(ReadOnlySpan<char> @string, Key primary, [NotNullWhen(true)] out string? key);
}

internal interface IForeign<T> : IForeign where T : IForeign
{
    static abstract T Create(KeyInfo info);
}
