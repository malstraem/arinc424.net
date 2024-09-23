namespace Arinc424.Processing;

internal abstract class IdentifierTrigger<TRecord> : ITrigger<TRecord> where TRecord : Record424, IIdentity
{
    public static bool Check(TRecord first, TRecord second) => first.Identifier != second.Identifier;
}
