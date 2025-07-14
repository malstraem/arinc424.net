using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal interface IPolymorphForeign
{
    static abstract bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        in KeyInfo info,
        in KeyInfo primary,
        Type type,
        [NotNullWhen(true)] out string? key
    );
}
