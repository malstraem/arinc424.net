using System.Diagnostics.CodeAnalysis;

namespace Arinc424;

public record KeyInfo(Range Id, Range? Icao, Range? Port)
{
    internal bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        [NotNullWhen(true)] out string? key
    )
    {
        key = @string[Id].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (Icao.HasValue)
            key += @string[Icao.Value].ToString();

        if (Port.HasValue)
            key += @string[Port!.Value].Trim().ToString();

        return true;
    }

    internal bool TryGetKey
    (
        ReadOnlySpan<char> @string,
        KeyInfo primary,
        [NotNullWhen(true)] out string? key
    )
    {
        key = @string[Id].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (IsIcao && primary.IsIcao)
            key += @string[Icao!.Value].ToString();

        if (IsPort && primary.IsPort)
            key += @string[Port!.Value].Trim().ToString();

        return true;
    }

    internal string GetKeyWithoutPort
    (
        ReadOnlySpan<char> @string,
        KeyInfo primary,
        [NotNullWhen(true)] out string? key)
    {
        key = @string[Id].Trim().ToString();

        if (IsIcao && primary.IsIcao)
            key += @string[Icao!.Value].ToString();

        return key;
    }

    internal bool IsIcao => Icao.HasValue;

    internal bool IsPort => Port.HasValue;
}
