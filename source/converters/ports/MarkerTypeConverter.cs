using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal class MarkerTypeConverter : IStringConverter<MarkerTypeConverter, MarkerType>
{
    public static MarkerType Convert(ReadOnlySpan<char> @string) => @string[0] is 'L' ? MarkerType.Locator : MarkerType.Unknown
    | @string[1] switch
    {
        'I' => MarkerType.Inner,
        'M' => MarkerType.Middle,
        'O' => MarkerType.Outer,
        'B' => MarkerType.Back,
        _ => MarkerType.Unknown
    };
}
