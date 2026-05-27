namespace Arinc424.Attributes;

/**<summary>
Specifies the range of a field within an <c>ARINC-424</c> string.
Comes before <see cref="FieldAttribute{TRecord}"/>.
</summary>
<inheritdoc/>*/
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute(int left, int right) : RangeAttribute(left, right);

/**<summary>
Specifies the target field range for <typeparamref name="R"/>
within an <c>ARINC-424</c> string.
</summary>
<inheritdoc/>
<typeparam name="R">Target record type in which the field is defined.</typeparam>*/
internal sealed class FieldAttribute<R>(int left, int right) : FieldAttribute(left, right)
    where R : Record424
{
    internal override bool IsMatch<M>() => typeof(M).IsAssignableTo(typeof(R));

    internal override bool IsTarget => true;
}
