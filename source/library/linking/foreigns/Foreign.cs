using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class Foreign(KeyInfo info) : Key(info), IForeign<Foreign>
{
    public static Foreign Create(KeyInfo info) => new(info);

    public bool TryGetKey(ReadOnlySpan<char> @string, Key primary, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (IsIcao && primary.IsIcao)
            key += @string[info.Icao!.Value].ToString();

        if (IsPort && primary.IsPort)
            key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
