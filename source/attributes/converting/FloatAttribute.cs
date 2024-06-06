namespace Arinc424.Attributes;

/// <summary>
/// Specifies that property value is a floating with point suppressed and will be converted and divided by <paramref name="divisor"/> value.
/// </summary>
/// <param name="divisor"></param>
[AttributeUsage(AttributeTargets.Property)]
internal sealed class FloatAttribute(float divisor) : DecodeAttribute<float>
{
    internal override Result<float> Convert(ReadOnlySpan<char> @string) => float.TryParse(@string, out float value)
        ? value / divisor
        : new Result<float>($"'{value}' can't be parsed as a float.");
}
