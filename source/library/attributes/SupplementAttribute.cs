namespace Arinc424.Attributes;

/// <summary>A base attribute that can be versioned.</summary>
internal abstract class SupplementAttribute : Attribute
{
    public Supplement Start { get; set; } = Supplement.V18;

    public Supplement End { get; set; } = Supplement.V23;

    internal virtual bool IsTarget => false;

    /**<summary>
    Defines that a type matches the attribute.
    </summary>
    <typeparam name="TMatch">Type to match.</typeparam>
    <remarks><see langword="false"/> is forced cause non target attribute will be come by default.</remarks>*/
    internal virtual bool IsMatch<TMatch>() where TMatch : Record424 => false;
}
