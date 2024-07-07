using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

internal sealed class Primary(KeyRanges ranges) : Key(ranges)
{
    internal static Primary? Create(Type type)
    {
        var identifier = type.GetCustomAttribute<IdentifierAttribute>();

        if (identifier is null)
            return null;

        KeyRanges ranges = new()
        {
            Port = type.GetCustomAttribute<PortAttribute>()?.Range,
            Icao = type.GetCustomAttribute<IcaoAttribute>()?.Range,
            Identifier = identifier.Range
        };

        return new Primary(ranges);
    }

    internal bool TryGetKey(ReadOnlySpan<char> @string, [NotNullWhen(true)] out string? key)
    {
        key = @string[ranges.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (ranges.Icao.HasValue)
            key += @string[ranges.Icao.Value].ToString();

        if (ranges.Port.HasValue)
            key += @string[ranges.Port.Value].Trim().ToString();

        return true;
    }
}
