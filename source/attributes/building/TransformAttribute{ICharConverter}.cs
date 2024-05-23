namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be transformed by associated converter before assignment using <see cref="CharacterAttribute"/> index.
/// </summary>
internal abstract class TransformAttribute : Attribute
{
    internal abstract object Convert(char @char);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="ICharConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum)]
internal class TransformAttribute<TConverter> : TransformAttribute where TConverter : ICharConverter
{
    internal override object Convert(char @char) => TConverter.Convert(@char);
}
