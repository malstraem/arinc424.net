using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class Foreign(LinkInfo info) : Key(info)
{
    internal virtual bool TryGetKey(ReadOnlySpan<char> @string, Key primary, [NotNullWhen(true)] out string? key)
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

internal sealed class HoldingFixForeign(LinkInfo info) : Foreign(info)
{
    private static readonly Range range = 10..12;

    internal override bool TryGetKey(ReadOnlySpan<char> @string, Key primary, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        key += @string[info.Icao!.Value].ToString();

        if (@string[range].Trim().IsEmpty && @string[info.Port!.Value] == "ENRT")
            return true;

        key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
