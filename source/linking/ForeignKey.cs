namespace Arinc424.Linking;

internal class ForeignKey(int length, ReadOnlyMemory<Range> ranges, ReadOnlyMemory<ForeignExceptAttribute?> exceptAttributes) : Key(length, ranges)
{
    private readonly ReadOnlyMemory<ForeignExceptAttribute?> exceptAttributes = exceptAttributes;

    internal static ForeignKey Create(ForeignAttribute[] foreignAttributes)
    {
        int keyLength = 0;
        List<Range> ranges = [];
        List<ForeignExceptAttribute?> exceptAttributes = [];

        foreach (var foreign in foreignAttributes)
        {
            var range = foreign.Range;
            keyLength += range.End.Value - range.Start.Value;

            ranges.Add(range);
            exceptAttributes.Add(foreign is ForeignExceptAttribute exceptAttribute ? exceptAttribute : null);
        }
        return new ForeignKey(keyLength, ranges.ToArray(), exceptAttributes.ToArray());
    }

    internal bool TryGetKey(ReadOnlySpan<char> @string, Type type, out string key)
    {
        int index = 0, exceptIndex = 0;

        var excepts = exceptAttributes.Span;

        Span<char> chars = stackalloc char[length];

        foreach (var range in ranges.Span)
        {
            var except = excepts[exceptIndex];

            if (except is not null && except.Types.Contains(type))
            {
                exceptIndex++;
                continue;
            }

            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                char @char = @string[i];

                if (!char.IsWhiteSpace(@char))
                    chars[index++] = @char;
            }
            exceptIndex++;
        }
        unsafe
        {
            fixed (char* ptr = chars)
                key = new string(ptr, 0, index);
        }
        return !string.IsNullOrEmpty(key);
    }
}
