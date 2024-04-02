namespace Arinc424.Attributes;

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
internal class FieldAttribute<TRecord>(int start, int end) : TargetFieldAttribute(start, end, typeof(TRecord)) where TRecord : Record424;
