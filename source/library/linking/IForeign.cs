using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal interface IForeign
{
    static abstract bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        in KeyInfo info,
        in KeyInfo primary,
        [NotNullWhen(true)] out string? key
    );
}
