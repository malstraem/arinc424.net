namespace Arinc424.Attributes;

/**<summary>
Specifies that the character will be converted before assignment
using <see cref="CharacterAttribute"/> index.
</summary>*/
internal abstract class TransformAttribute : SupplementAttribute;

/// <inheritdoc/>
/// <typeparam name="TType">The type of value being converted from the character.</typeparam>
internal abstract class TransformAttribute<TType> : TransformAttribute where TType : Enum
{
    internal abstract bool TryConvert(char @char, out TType value);
}

/**<inheritdoc/>
<typeparam name="TConverter">Associated <see cref="ICharConverter{TType}"/>.</typeparam>
<typeparam name="TType"><inheritdoc/></typeparam>*/
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum, AllowMultiple = true)]
internal sealed class TransformAttribute<TConverter, TType> : TransformAttribute<TType>
    where TConverter : ICharConverter<TType>
    where TType : Enum
{
    internal override bool TryConvert(char @char, out TType value)
        => TConverter.TryConvert(@char, out value);
}
