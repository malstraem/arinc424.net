namespace Arinc424.Attributes;

/// <summary>
/// Specifies the target field range within an ARINC-424 string.
/// </summary>
/// <remarks>Used by sequence or base types to define different ranges.</remarks>
internal abstract class TargetFieldAttribute(int start, int end, Type targetType) : FieldAttribute(start, end)
{
    /// <summary>
    /// Target record type in which the field is defined.
    /// </summary>
    public Type TargetType { get; } = targetType;
}

/// <summary>
/// Specifies the target field range for <typeparamref name="TRecord"/> within an ARINC-424 string.
/// </summary>
/// <typeparam name="TRecord">Target record type in which the field is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute<TRecord>(int start, int end) : TargetFieldAttribute(start, end, typeof(TRecord)) where TRecord : Record424;
