namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the range of a field within an ARINC-424 string.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class FieldAttribute(int start, int end) : RangeAttribute(start, end) { }

/// <inheritdoc cref="FieldAttribute"/>
internal abstract class TargetFieldAttribute(int start, int end, Type targetType) : FieldAttribute(start, end)
{
    /// <summary>
    /// Target record type in which the field is defined.
    /// </summary>
    internal Type TargetType { get; } = targetType;
}

/// <inheritdoc cref="FieldAttribute"/>
/// <typeparam name="TRecord">Target record type in which the field is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class FieldAttribute<TRecord>(int start, int end) : TargetFieldAttribute(start, end, typeof(TRecord)) where TRecord : Record424 { }
