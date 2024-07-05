using System.Reflection;

namespace Arinc424.Linking;

internal abstract class Primary(KeyRanges ranges) : Key(ranges)
{
    internal abstract bool TryGetKey(ReadOnlySpan<char> @string, out string? key);
}

internal sealed class Primary<TRecord>(KeyRanges ranges) : Primary(ranges) where TRecord : Record424
{
    internal static Primary<TRecord>? Create()
    {
        var type = typeof(TRecord);

        var identifier = type.GetCustomAttribute<IdentifierAttribute>();

        if (identifier is null)
            return null;

        KeyRanges ranges = new()
        {
            Port = type.GetCustomAttribute<PortAttribute>()?.Range,
            Icao = type.GetCustomAttribute<IcaoAttribute>()?.Range,
            Identifier = identifier.Range
        };

        return new Primary<TRecord>(ranges);
    }

    internal override bool TryGetKey(ReadOnlySpan<char> @string, out string key)
    {
        key = @string[ranges.Identifier].Trim().ToString();

        if (ranges.Icao.HasValue)
            key += @string[ranges.Icao.Value].ToString();

        if (ranges.Port.HasValue)
            key += @string[ranges.Port.Value].Trim().ToString();

        return !string.IsNullOrEmpty(key);
    }
}
