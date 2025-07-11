using System.Diagnostics.CodeAnalysis;

namespace Arinc424.Linking;

internal class HoldingFixForeign(KeyInfo info) : Key(info), IPolymorphForeign<HoldingFixForeign>
{
    private static readonly Range range = 10..12;

    public static HoldingFixForeign Create(KeyInfo info) => new(info);

    public bool TryGetKey(ReadOnlySpan<char> @string, Type type, Key primary, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        key += @string[info.Icao!.Value].ToString();

        if (@string[range].Trim().IsEmpty && @string[info.Port!.Value].Equals("ENRT", StringComparison.InvariantCulture))
            return true;

        key += @string[info.Port!.Value].Trim().ToString();

        return true;
    }
}
