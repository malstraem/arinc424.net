namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the character index within an ARINC-424 string.
/// </summary>
/// <param name="index">Character index.</param>
/// <remarks>Note that the <paramref name="index"/> must completely match those defined in the specification.</remarks>
[AttributeUsage(AttributeTargets.Property)]
internal class CharacterAttribute(int index) : Attribute
{
    /// <summary>
    /// Character index within an string.
    /// </summary>
    internal int Index { get; } = index - 1;
}

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
