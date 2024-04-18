namespace Arinc424.Linking;

internal class Key(int length, ReadOnlyMemory<Range> ranges)
{
    protected readonly int length = length;

    protected readonly ReadOnlyMemory<Range> ranges = ranges;
}
