namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the value will be decoded by associated converter before assignment using <see cref="FieldAttribute"/> range.
/// </summary>
internal abstract class DecodeAttribute : Attribute
{
    internal abstract Result<object> Convert(ReadOnlySpan<char> @string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property)]
internal class DecodeAttribute<TConverter> : DecodeAttribute where TConverter : IStringConverter
{
    internal override Result<object> Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}
