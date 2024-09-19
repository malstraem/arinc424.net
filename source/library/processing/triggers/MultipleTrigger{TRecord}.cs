namespace Arinc424.Processing;

internal abstract class MultipleTrigger<TRecord> : ITrigger<TRecord> where TRecord : Record424, IMultiple
{
    public static bool Check(TRecord current, TRecord next)
        => char.IsWhiteSpace(current.MultipleCode) || char.IsWhiteSpace(next.MultipleCode) || next.MultipleCode <= current.MultipleCode;
}
