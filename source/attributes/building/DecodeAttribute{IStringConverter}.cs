using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies that the property value must be decoded from the field string using the associated converter before assignment.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class DecodeAttribute : Attribute
{
    internal abstract object Convert(string @string);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="IStringConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property)]
internal class DecodeAttribute<TConverter> : DecodeAttribute where TConverter : IStringConverter
{
    internal override object Convert(string @string) => TConverter.Convert(@string);
}
