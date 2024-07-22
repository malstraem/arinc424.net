namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be transformed by associated converter before assignment using <see cref="CharacterAttribute"/> index.
/// </summary>
internal abstract class TransformAttribute(Supplement start) : SupplementAttribute(start);

/// <inheritdoc/>
/// <typeparam name="TType">Type in which the value will be transformed from the char.</typeparam>
internal abstract class TransformAttribute<TType>(Supplement start) : TransformAttribute(start) where TType : Enum
{
    internal abstract TType Convert(char @char);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="ICharConverter{TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum)]
internal sealed class TransformAttribute<TConverter, TType>(Supplement start = Supplement.V18) : TransformAttribute<TType>(start)
    where TConverter : ICharConverter<TType>
    where TType : Enum
{
    internal override TType Convert(char @char) => TConverter.Convert(@char);
}
