using System.Diagnostics.CodeAnalysis;

namespace Arinc424;

public readonly struct KeyInfo(Range id, Range? icao, Range? port)
{
    public readonly Range Id = id;

    public readonly Range? Icao = icao, Port = port;

    internal bool TryGetKey(ReadOnlySpan<char> @string, [NotNullWhen(true)] out string? key)
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
        ref readonly KeyInfo primary,
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
        ref readonly KeyInfo primary,
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
