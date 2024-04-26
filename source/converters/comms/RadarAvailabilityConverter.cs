namespace Arinc424.Converters;

internal abstract class RadarAvailabilityConverter : ICharConverter<RadarAvailabilityConverter, bool?>
{
    public static bool? Convert(char @char) => @char switch
    {
        'R' => true,
        'N' => false,
        'U' or _ => null
    };
}
