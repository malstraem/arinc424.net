namespace Arinc424.Attributes;

/// <summary>
/// Specifies the index of a character within an <c>ARINC-424</c> string. Must come before <see cref="CharacterAttribute{TRecord}"/>.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute(int index, Supplement start = Supplement.V18) : IndexAttribute(index, start);

/// <summary>
/// Specifies the target character index for <typeparamref name="TRecord"/> within an <c>ARINC-424</c> string.
/// </summary>
/// <inheritdoc/>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
internal class CharacterAttribute<TRecord>(int index, Supplement start = Supplement.V18) : CharacterAttribute(index, start)
    where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));

    internal override bool IsTarget => true;
}