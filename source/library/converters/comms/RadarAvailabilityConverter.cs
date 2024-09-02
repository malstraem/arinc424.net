namespace Arinc424.Converters;

internal abstract class RadarAvailabilityConverter : ICharConverter<Bool>
{
    public static Result<Bool> Convert(char @char) => char.IsWhiteSpace(@char) ? Bool.Unknown : @char switch
    {
        'R' => Bool.Yes,
        'N' => Bool.No,
        'U' => Bool.Unspecified,
        _ => $"Char '{@char}' is not valid"
    };
}
