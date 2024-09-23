namespace Arinc424.Attributes;

using static System.Globalization.NumberStyles;

/// <summary>
/// Specifies that property value is a floating with point suppressed and will be converted and divided by <paramref name="divisor"/> value.
/// </summary>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class FloatAttribute(float divisor) : DecodeAttribute<float>
{
    private const System.Globalization.NumberStyles style = None | AllowLeadingSign | AllowLeadingWhite;

    internal override Result<float> Convert(ReadOnlySpan<char> @string) => float.TryParse(@string, style, null, out float value)
        ? value / divisor
        : @string;
}
