namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property value must be decoded from the field string using the associated converter before assignment.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class DecodeAttribute : Attribute
{
    internal abstract object Convert(ReadOnlySpan<char> @string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property)]
internal class DecodeAttribute<TConverter> : DecodeAttribute where TConverter : IStringConverter
{
    internal override object Convert(ReadOnlySpan<char> @string) => TConverter.Convert(@string);
}
