namespace Arinc424.Attributes;

internal abstract class SupplementAttribute(Supplement start, Supplement end = Supplement.V23) : Attribute
{
    internal Supplement Start { get; } = start;

    internal Supplement End { get; } = end;

    internal virtual bool IsTarget => false;

    /// <summary>
    /// Defines that a record type matches the attribute (from base types).
    /// </summary>
    /// <typeparam name="TMatch">Record type to match.</typeparam>
    /// <remarks><see langword="False"/> is forced cause non target attribute will be come by default.</remarks>
    internal virtual bool IsMatch<TMatch>() where TMatch : Record424 => false;
}
