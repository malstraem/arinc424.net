namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal sealed class FloatAttribute(float divisor) : DecodeAttribute<float>
{
    internal override Result<float> Convert(ReadOnlySpan<char> @string) => float.TryParse(@string, out float value)
        ? value / divisor
        : new Result<float>($"'{value}' can't be parsed as a float.");
}
