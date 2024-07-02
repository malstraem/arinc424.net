namespace Arinc424.Linking;

internal abstract class Foreign
{
    internal abstract bool TryGetKey(ReadOnlySpan<char> @string, InfoAttribute info, out string? key);
}

internal class Foreign<TType>(Range identifier, Range? icao, Range? port) : Foreign where TType : class
{
    private readonly Range identifier = identifier;

    private readonly Range? icao = icao, port = port;

    internal override bool TryGetKey(ReadOnlySpan<char> @string, InfoAttribute info, out string? key)
    {
        key = null;

        if (info.Primary is null) // todo: remove
            return false;

        var primary = info.Primary!;

        key = @string[identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (primary.Icao.HasValue && icao.HasValue)
            key += @string[icao.Value].ToString();

        if (primary.Port.HasValue && port.HasValue && !primary.IsPortOptional)
            key += @string[port.Value].Trim().ToString();

        return true;
    }
}
