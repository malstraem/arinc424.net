using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class PolymorphForeign : IPolymorphForeign
{
    public static bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        in KeyInfo info,
        in KeyInfo primary,
        Type type,
        [NotNullWhen(true)] out string? key
    )
    => Foreign.TryGetKey(@string, in info, in primary, out key);
}
