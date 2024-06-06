using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

[Obsolete("todo separated types")]
internal abstract class NondirectionalTypeConverter : IStringConverter<NondirectionalTypeConverter, NavaidType>
{
    public static Result<NavaidType> Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'H' => NavaidType.Nondirectional,
        'S' => NavaidType.SABH,
        'M' => NavaidType.Marine,
        _ => NavaidType.Unknown
    }
    | @string[1] switch
    {
        'I' => NavaidType.InnerMarker,
        'M' => NavaidType.MiddleMarker,
        'O' => NavaidType.OuterMarker,
        'C' => NavaidType.BackMarker,
        _ => NavaidType.Unknown
    };
}
