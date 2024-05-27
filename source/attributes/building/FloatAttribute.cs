namespace Arinc424.Attributes;

[AttributeUsage(AttributeTargets.Property)]
internal class FloatAttribute(float divisor) : DecodeAttribute
{
    internal override Result<object> Convert(ReadOnlySpan<char> @string) => float.TryParse(@string, out float value)
        ? value / divisor
        : new Result<object>($"'{value}' can't be parsed as a float.");
}
