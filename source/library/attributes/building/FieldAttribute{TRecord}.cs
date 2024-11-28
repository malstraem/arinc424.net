namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of a field within an <c>ARINC-424</c> string. Comes before <see cref="FieldAttribute{TRecord}"/>.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute(int left, int right, Supplement start = Supplement.V18) : RangeAttribute(left, right, start);

/// <summary>
/// Specifies the target field range for <typeparamref name="TRecord"/> within an <c>ARINC-424</c> string.
/// </summary>
/// <inheritdoc/>
/// <typeparam name="TRecord">Target record type in which the field is defined.</typeparam>
internal sealed class FieldAttribute<TRecord>(int left, int right, Supplement start = Supplement.V18) : FieldAttribute(left, right, start)
    where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));

    internal override bool IsTarget => true;
}
