namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the range of a field within an ARINC-424 string.
/// </summary>
/// <param name="start">Left bound.</param>
/// <param name="end">Right bound.</param>
/// <remarks>Note that the bounds must completely match those defined in the specification.</remarks>
[AttributeUsage(AttributeTargets.Property)]
internal class FieldAttribute(int start, int end) : Attribute
{
    /// <summary>
    /// Field range within an string.
    /// </summary>
    internal Range Range { get; } = new Range(start - 1, end);
}

/// <inheritdoc/>
internal abstract class TargetFieldAttribute(int start, int end, Type targetType) : FieldAttribute(start, end)
{
    /// <summary>
    /// Target record type in which the field is defined.
    /// </summary>
    internal Type TargetType { get; } = targetType;
}

/// <inheritdoc/>
/// <param name="start">Left bound.</param>
/// <param name="end">Right bound.</param>
/// <typeparam name="TRecord">Target record type in which the field is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute<TRecord>(int start, int end) : TargetFieldAttribute(start, end, typeof(TRecord)) where TRecord : Record424 { }
