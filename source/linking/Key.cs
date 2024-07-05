namespace Arinc424.Linking;

internal abstract class Key(KeyRanges ranges)
{
    protected KeyRanges ranges = ranges;

    internal KeyRanges Ranges => ranges;

    internal bool IsIcao => ranges.Icao is not null;

    internal bool IsPort => ranges.Port is not null;
}
