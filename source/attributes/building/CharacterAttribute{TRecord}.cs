namespace Arinc424.Attributes;

/// <summary>
/// Specifies the index of a character within an ARINC-424 string. Must come before <see cref="CharacterAttribute{TRecord}"/>.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class CharacterAttribute(int index) : IndexAttribute(index)
{
    internal virtual bool IsMatch<TMatch>() where TMatch : Record424 => false;
}

/// <summary>
/// Specifies the target character index for <typeparamref name="TRecord"/> within an ARINC-424 string.
/// Used by sequence or base types to define different indexes.
/// </summary>
/// <inheritdoc/>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute<TRecord>(int index) : CharacterAttribute(index) where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));
}
