using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal sealed class Foreign(LinkInfo info) : Key(info)
{
    internal bool TryGetKey(ReadOnlySpan<char> @string, Key primary, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (primary.IsIcao && IsIcao)
            key += @string[info.Icao!.Value].ToString();

        if (primary.IsPort && IsPort)
            key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
