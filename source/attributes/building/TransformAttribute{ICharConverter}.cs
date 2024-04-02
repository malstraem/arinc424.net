using Arinc424.Converters;

namespace Arinc424.Attributes;

/// <summary>
/// Specifies that the property value must be transformed from the field character using the associated converter before assignment.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal abstract class TransformAttribute : Attribute
{
    internal abstract object Convert(char @char);
}

/// <inheritdoc/>
/// <typeparam name="TConverter">Associated <see cref="ICharConverter"/>.</typeparam>
[AttributeUsage(AttributeTargets.Property)]
internal class TransformAttribute<TConverter> : TransformAttribute where TConverter : ICharConverter
{
    internal override object Convert(char @char) => TConverter.Convert(@char);
}
