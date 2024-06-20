namespace Arinc424.Building;

internal class Build<TRecord>(TRecord record) : Build(record) where TRecord : Record424
{
    internal new TRecord Record { get; } = record;
}
