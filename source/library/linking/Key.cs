namespace Arinc424.Linking;

internal abstract class Key(LinkInfo info)
{
    protected LinkInfo info = info;

    internal bool IsIcao = info.Icao is not null;

    internal bool IsPort = info.Port is not null;

    internal LinkInfo Info => info;
}
