using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Linking;

internal sealed class Primary(LinkInfo info) : Key(info)
{
    internal static Primary? Create(Type type)
    {
        var identifier = type.GetCustomAttribute<IdentifierAttribute>();

        if (identifier is null)
            return null;

        LinkInfo info = new()
        {
            Port = type.GetCustomAttribute<PortAttribute>()?.Range,
            Icao = type.GetCustomAttribute<IcaoAttribute>()?.Range,
            Identifier = identifier.Range
        };
        return new Primary(info);
    }

    internal bool TryGetKey(ReadOnlySpan<char> @string, [NotNullWhen(true)] out string? key)
    {
        key = @string[info.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (info.Icao.HasValue)
            key += @string[info.Icao.Value].ToString();

        if (info.Port.HasValue)
            key += @string[info.Port.Value].Trim().ToString();

        return true;
    }
}
