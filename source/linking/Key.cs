namespace Arinc424.Linking;

internal abstract class Key(KeyRanges ranges)
{
    protected KeyRanges ranges = ranges;

    [Obsolete("todo or remove")]
    protected static ReadOnlySpan<char> Concat(ReadOnlySpan<char> one, ReadOnlySpan<char> other, Span<char> target)
    {
        int index = 0;

        for (int i = 0; i < one.Length; i++)
        {
            char @char = one[i];

            if (!char.IsWhiteSpace(@char))
                target[index++] = @char;
        }
        for (int i = 0; i < other.Length; i++)
        {
            char @char = other[i];

            if (!char.IsWhiteSpace(@char))
                target[index++] = @char;
        }
        unsafe
        {
            fixed (char* ptr = target)
                return new ReadOnlySpan<char>(ptr, index);
        }
    }

    internal bool IsIcao = ranges.Icao is not null;

    internal bool IsPort = ranges.Port is not null;

    internal KeyRanges Ranges => ranges;
}
