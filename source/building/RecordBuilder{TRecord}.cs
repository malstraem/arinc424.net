namespace Arinc.Spec424.Building;

internal static class RecordBuilder<TRecord> where TRecord : Record424
{
    private readonly static BuildInfo info = new(typeof(TRecord));

    internal static TRecord Build(string @string) => (TRecord)RecordBuilder.Build(info, @string);
}
