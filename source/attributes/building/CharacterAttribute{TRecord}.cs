namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the target character index within an ARINC-424 string.
/// </summary>
/// <param name="targetType">The target type for which the index is defined.</param>
/// <remarks>Used by sequence or base types to define different positions.</remarks>
internal abstract class TargetCharacterAttribute(int index, Type targetType) : CharacterAttribute(index)
{
    /// <summary>
    /// The target type for which the index is defined.
    /// </summary>
    internal Type TargetType { get; } = targetType;
}

/// <inheritdoc/>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute<TRecord>(int index) : TargetCharacterAttribute(index, typeof(TRecord));
