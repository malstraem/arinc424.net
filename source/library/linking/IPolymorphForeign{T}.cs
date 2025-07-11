using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal interface IPolymorphForeign : IKey
{
    internal bool TryGetKey(ReadOnlySpan<char> @string, Type type, Key primary, [NotNullWhen(true)] out string? key);
}

internal interface IPolymorphForeign<T> : IPolymorphForeign where T : IPolymorphForeign
{
    static abstract T Create(KeyInfo info);
}
