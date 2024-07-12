namespace Arinc424.Attributes;

/// <summary>
/// Specifies the index of a character within an <c>ARINC-424</c> string. Must come before <see cref="CharacterAttribute{TRecord}"/>.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute(int index, Supplement supplement = Supplement.None) : IndexAttribute(index, supplement)
{
    /// <summary>
    /// Defines that a record type matches the attribute (from base types).
    /// </summary>
    /// <typeparam name="TMatch">Record type to match.</typeparam>
    /// <remarks><see langword="False"/> is forced cause non target attribute will be come by default.</remarks>
    internal virtual bool IsMatch<TMatch>() where TMatch : Record424 => false;
}

/// <summary>
/// Specifies the target character index for <typeparamref name="TRecord"/> within an <c>ARINC-424</c> string.
/// Used to define different indexes.
/// </summary>
/// <inheritdoc/>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
internal class CharacterAttribute<TRecord>(int index, Supplement supplement = Supplement.None) : CharacterAttribute(index, supplement)
    where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));
}
