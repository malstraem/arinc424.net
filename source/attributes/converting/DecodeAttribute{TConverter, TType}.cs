namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be decoded by associated converter before assignment using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class DecodeAttribute : Attribute;

/// <inheritdoc/>
/// <typeparam name="TType">Type in which the value will be decoded from the string.</typeparam>
internal abstract class DecodeAttribute<TType> : DecodeAttribute where TType : notnull
{
    internal abstract Result<TType> Convert(ReadOnlySpan<char> @string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter{, TType}"/>.</typeparam>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
internal sealed class DecodeAttribute<TConverter, TType> : DecodeAttribute<TType>
    where TConverter : IStringConverter<TType> where TType : notnull
{
    internal override Result<TType> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}
