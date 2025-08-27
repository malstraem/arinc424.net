namespace Arinc424.Model;

public class RangeModel(Range range, ReadOnlyMemory<char> chars)
{
    public Range Range { get; } = range;

    public ReadOnlyMemory<char> Chars { get; } = chars;
}
