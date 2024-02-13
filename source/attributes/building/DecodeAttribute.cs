using Arinc.Spec424.Terms.Converters;

namespace Arinc.Spec424.Attributes;

/// <summary>
/// Specifies that the property is a string and the value must be decoded using the associated converter before assignment.
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
