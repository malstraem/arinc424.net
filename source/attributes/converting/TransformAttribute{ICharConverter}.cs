namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be transformed by associated converter before assignment using <see cref="CharacterAttribute"/> index.
/// </summary>
internal abstract class TransformAttribute : Attribute;

/// <inheritdoc/>
/// <typeparam name="TType">Type in which the value will be transformed from the char.</typeparam>
internal abstract class TransformAttribute<TType> : TransformAttribute where TType : Enum
{
    internal abstract TType Convert(char @char);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="ICharConverter{, TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum)]
internal sealed class TransformAttribute<TConverter, TType> : TransformAttribute<TType>
    where TConverter : ICharConverter<TType> where TType : Enum
{
    internal override TType Convert(char @char) => TConverter.Convert(@char);
}
