namespace Arinc424.Converters;

internal abstract class RadarAvailabilityConverter : ICharConverter<Bool>
{
    public static Bool Convert(char @char) => @char switch
    {
        'R' => Bool.Yes,
        'N' => Bool.No,
        'U' => Bool.Unspecified,
        _ => Bool.Unknown
    };
}
