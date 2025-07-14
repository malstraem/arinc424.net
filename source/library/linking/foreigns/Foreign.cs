using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class Foreign : IForeign
{
    public static bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        in KeyInfo info,
        in KeyInfo primary,
        [NotNullWhen(true)] out string? key
    )
    {
        key = @string[info.Id].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (info.IsIcao && primary.IsIcao)
            key += @string[info.Icao!.Value].ToString();

        if (info.IsPort && primary.IsPort)
            key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
