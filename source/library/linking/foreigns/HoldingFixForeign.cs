using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class HoldingFixForeign : IPolymorphForeign
{
    private static readonly Range range = 10..12;

    public static bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        in KeyInfo info,
        in KeyInfo primary,
        Type type,
        [NotNullWhen(true)] out string? key
    )
    {
        key = @string[info.Id].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        key += @string[info.Icao!.Value].ToString();

        if (@string[range].Trim().IsEmpty && @string[info.Port!.Value].Equals("ENRT", StringComparison.InvariantCulture))
            return true;

        key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
