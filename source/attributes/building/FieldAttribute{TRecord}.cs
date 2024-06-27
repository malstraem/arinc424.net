namespace Arinc424.Attributes;

/// <summary>
/// Specifies the range of a field within an <c>ARINC-424</c> string. Must come before <see cref="FieldAttribute{TRecord}"/>.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class FieldAttribute(int start, int end) : RangeAttribute(start, end)
{
    /// <inheritdoc cref="CharacterAttribute.IsMatch{TMatch}"/>
    internal virtual bool IsMatch<TMatch>() where TMatch : Record424 => false;
}

/// <summary>
/// Specifies the target field range for <typeparamref name="TRecord"/> within an <c>ARINC-424</c> string.
/// </summary>
/// <inheritdoc/>
/// <typeparam name="TRecord">Target record type in which the field is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute<TRecord>(int start, int end) : FieldAttribute(start, end) where TRecord : Record424
{
    internal override bool IsMatch<TMatch>() => typeof(TMatch).IsAssignableTo(typeof(TRecord));
}
