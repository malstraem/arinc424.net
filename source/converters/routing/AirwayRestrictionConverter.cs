using Arinc424.Routing.Terms;

namespace Arinc424.Converters;

internal abstract class AirwayRestrictionConverter : ICharConverter<AirwayRestrictionConverter, AirwayRestriction>
{
    public static AirwayRestriction Convert(char @char) => char.IsWhiteSpace(@char) ? AirwayRestriction.None : @char switch
    {
        'F' => AirwayRestriction.Forward,
        'B' => AirwayRestriction.Backward,
        _ => AirwayRestriction.Unknown
    };
}