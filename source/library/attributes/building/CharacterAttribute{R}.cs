namespace Arinc424.Attributes;

/**<summary>
Specifies the index of a character within an <c>ARINC-424</c> string.
Comes before <see cref="CharacterAttribute{R}"/>.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute(int index) : IndexAttribute(index);

/**<summary>
Specifies the target character index for <typeparamref name="R"/> within an <c>ARINC-424</c> string.
</summary>
<inheritdoc/>
<typeparam name="R">Target type of record that index is defined.</typeparam>*/
internal sealed class CharacterAttribute<R>(int index) : CharacterAttribute(index)
    where R : Record424
{
    internal override bool IsMatch<M>() => typeof(M).IsAssignableTo(typeof(R));

    internal override bool IsTarget => true;
}
