namespace Arinc424.Attributes;

/**<summary>
Specifies that property value is a <c>Required Navigation Performance</c> and will be parsed.
</summary>
<remarks>See section 5.211.</remarks>*/
internal sealed class PerformanceAttribute : DecodeAttribute<float>
{
    internal override Result<float> Convert(ReadOnlySpan<char> @string) => !float.TryParse(@string[..2], out float value)
        ? @string
        : !int.TryParse(@string[2..3], out int exp)
            ? @string
            : exp == 0 ? value : value / MathF.Pow(10, exp);
}
