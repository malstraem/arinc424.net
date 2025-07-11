using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class AltitudeCenterForeign(KeyInfo info) : Key(info), IPolymorphForeign<AltitudeCenterForeign>
{
    private readonly Type omni = typeof(Navigation.Omnidirect);

    public static AltitudeCenterForeign Create(KeyInfo info) => new(info);

    public bool TryGetKey(ReadOnlySpan<char> @string, Type type, Key primary, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        key += @string[info.Icao!.Value].ToString();

        if (type != omni)
            key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
