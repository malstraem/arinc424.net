using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class AltitudeCenterForeign : IPolymorphForeign
{
    private static readonly Type omni = typeof(Navigation.Omnidirect);

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

        if (type != omni && primary.IsPort)
            key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
