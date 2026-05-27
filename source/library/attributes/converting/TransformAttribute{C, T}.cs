namespace Arinc424.Attributes;

/**<summary>
Specifies that the character will be converted before assignment
using <see cref="CharacterAttribute"/> index.
</summary>*/
internal abstract class TransformAttribute : SupplementAttribute;

/// <inheritdoc/>
/// <typeparam name="T">The type of value being converted from the character.</typeparam>
internal abstract class TransformAttribute<T> : TransformAttribute
    where T : Enum
{
    internal abstract bool TryConvert(char @char, out T value);
}

/**<inheritdoc/>
<typeparam name="C">Associated <see cref="ICharConverter{TType}"/>.</typeparam>
<typeparam name="T"><inheritdoc/></typeparam>*/
[AttributeUsage(AttributeTargets.Property | AttributeTargets.Enum, AllowMultiple = true)]
internal sealed class TransformAttribute<C, T> : TransformAttribute<T>
    where C : ICharConverter<T>
    where T : Enum
{
    internal override bool TryConvert(char @char, out T value) => C.TryConvert(@char, out value);
}
