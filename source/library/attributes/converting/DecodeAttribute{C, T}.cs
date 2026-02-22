namespace Arinc424.Attributes;

/**<summary>
Specifies that the string will be converted before assignment
using <see cref="FieldAttribute"/> range.
</summary>*/
internal abstract class DecodeAttribute : SupplementAttribute;

/// <inheritdoc/>
/// <typeparam name="T">The type of value being converted from the string.</typeparam>
internal abstract class DecodeAttribute<T> : DecodeAttribute
    where T : notnull
{
    internal abstract Result<T> Convert(ReadOnlySpan<char> @string);
}

/**<inheritdoc/>
<typeparam name="C">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
<typeparam name="T"><inheritdoc/></typeparam>*/
[AttributeUsage(AttributeTargets.Struct
              | AttributeTargets.Class
              | AttributeTargets.Enum
              | AttributeTargets.Property,
                AllowMultiple = true)]
internal class DecodeAttribute<C, T> : DecodeAttribute<T>
    where C : IStringConverter<T>
    where T : notnull
{
    internal override Result<T> Convert(ReadOnlySpan<char> @string) => C.Convert(@string);
}

/**<inheritdoc/>
<typeparam name="C">Associated <see cref="IStringConverter{TType}"/>.</typeparam>
<typeparam name="T"><inheritdoc/></typeparam>
<typeparam name="R">The target record type for which the attribute applies.</typeparam>*/
internal sealed class DecodeAttribute<C, T, R> : DecodeAttribute<C, T>
    where C : IStringConverter<T>
    where T : notnull
    where R : Record424
{
    internal override bool IsMatch<M>() => typeof(M).IsAssignableTo(typeof(R));

    internal override bool IsTarget => true;
}
