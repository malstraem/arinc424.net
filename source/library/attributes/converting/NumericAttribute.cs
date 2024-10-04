namespace Arinc424.Attributes;

using static System.Globalization.NumberStyles;

[AttributeUsage(AttributeTargets.Property)]
internal sealed class NumericAttribute<TParsable> : DecodeAttribute<TParsable>
    where TParsable : ISpanParsable<TParsable>
{
    private const System.Globalization.NumberStyles style = None | AllowLeadingSign | AllowLeadingWhite;

    internal override Result<TParsable> Convert(ReadOnlySpan<char> @string) => TParsable.TryParse(@string, null, out var value) ? value : @string;
}
