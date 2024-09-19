namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the character will be converted before assignment using <see cref="CharacterAttribute"/> index.
/// </summary>
internal abstract class TransformAttribute(Supplement start) : SupplementAttribute(start);

/// <inheritdoc/>
/// <typeparam name="TType">The type to which the character will be converted.</typeparam>
internal abstract class TransformAttribute<TType>(Supplement start) : TransformAttribute(start) where TType : Enum
{
    internal abstract bool TryConvert(char @char, out TType value);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="ICharConverter{TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum)]
internal sealed class TransformAttribute<TConverter, TType>(Supplement start = Supplement.V18) : TransformAttribute<TType>(start)
    where TConverter : ICharConverter<TType>
    where TType : Enum
{
    internal override bool TryConvert(char @char, out TType value) => TConverter.TryConvert(@char, out value);
}
