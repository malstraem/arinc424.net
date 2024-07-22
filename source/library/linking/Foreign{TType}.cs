namespace Arinc424.Linking;

internal sealed class Foreign<TType>(KeyRanges ranges) : Key(ranges) where TType : class
{
    internal bool TryGetKey(ReadOnlySpan<char> @string, Key primary, out string? key)
    {
        key = @string[ranges.Identifier].Trim().ToString();

        if (string.IsNullOrEmpty(key))
            return false;

        if (primary.IsIcao && IsIcao)
            key += @string[ranges.Icao!.Value].ToString();

        if (primary.IsPort && IsPort)
            key += @string[ranges.Port!.Value].Trim().ToString();

        return true;
    }
}
