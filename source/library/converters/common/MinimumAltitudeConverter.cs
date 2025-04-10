namespace Arinc424.Converters;

/**<summary>
Converter for <c>Minimum Off-route Altitude</c>.
</summary>
<remarks>See section 5.143.</remarks>*/
internal abstract class MinimumAltitudeConverter : IStringConverter<Altitude>
{
    public static Result<Altitude> Convert(ReadOnlySpan<char> @string)
    {
        if (@string is "UNK")
            return new Altitude(int.MinValue, AltitudeUnit.Unknown);

        var value = IntConverter.Convert(@string);

        return value.Invalid ? value.Bad : new Altitude(value.Value * 100, AltitudeUnit.Feet);
    }
}
