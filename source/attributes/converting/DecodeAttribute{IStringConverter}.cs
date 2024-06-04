namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be decoded by associated converter before assignment using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class DecodeAttribute : Attribute;

internal abstract class DecodeAttribute<TValue> : DecodeAttribute where TValue : notnull
{
    internal abstract Result<TValue> Convert(ReadOnlySpan<char> @string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
internal sealed class DecodeAttribute<TConverter, TValue> : DecodeAttribute<TValue> where TConverter : IStringConverter<TConverter, TValue> where TValue : notnull
{
    internal override Result<TValue> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}
