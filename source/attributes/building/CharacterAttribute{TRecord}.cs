namespace Arinc424.Attributes;

/// <summary>
/// Specifies the target character index within an ARINC-424 string.
/// </summary>
/// <remarks>Used by sequence or base types to define different indexes.</remarks>
internal abstract class TargetCharacterAttribute(int index, Type targetType) : CharacterAttribute(index)
{
    /// <summary>
    /// The target type for which the index is defined.
    /// </summary>
    internal Type TargetType { get; } = targetType;
}

/// <summary>
/// Specifies the target character index for <typeparamref name="TRecord"/> within an ARINC-424 string.
/// </summary>
/// <remarks>Used by sequence or base types to define different indexes.</remarks>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute<TRecord>(int index) : TargetCharacterAttribute(index, typeof(TRecord));
