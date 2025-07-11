namespace Arinc424.Linking;

internal interface IKey
{
    KeyInfo Info { get; }
}

internal abstract class Key(KeyInfo info) : IKey
{
    protected KeyInfo info = info;

    internal bool IsIcao = info.Icao is not null;

    internal bool IsPort = info.Port is not null;

    public KeyInfo Info => info;
}
