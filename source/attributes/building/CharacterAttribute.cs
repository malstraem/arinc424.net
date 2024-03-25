namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies the character index within an ARINC-424 string.
/// </summary>
/// <inheritdoc/>
[AttributeUsage(AttributeTargets.Property)]
internal class CharacterAttribute(int index) : IndexAttribute(index);
