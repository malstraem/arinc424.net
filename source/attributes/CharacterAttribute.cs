namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the character index within an ARINC-424 string.
/// </summary>
/// <param name="index">Character index.</param>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class CharacterAttribute(int index) : IndexAttribute(index) { }

/// <inheritdoc/>
/// <param name="targetType">Target type that index is defined.</param>
internal abstract class TargetCharacterAttribute(int index, Type targetType) : CharacterAttribute(index)
{
    /// <summary>
    /// Target type that index is defined.
    /// </summary>
    internal Type TargetType { get; } = targetType;
}

/// <inheritdoc/>
/// <typeparam name="TRecord">Target type of record that index is defined.</typeparam>
[AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
internal class CharacterAttribute<TRecord>(int index) : TargetCharacterAttribute(index, typeof(TRecord)) { }
