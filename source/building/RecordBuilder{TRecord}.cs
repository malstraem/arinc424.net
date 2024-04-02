namespace Arinc424.Building;

internal static class RecordBuilder<TRecord> where TRecord : Record424, new()
{
    private static readonly BuildInfo info = new(typeof(TRecord));

    internal static TRecord Build(string @string) => RecordBuilder.Build<TRecord>(info, @string);
}
