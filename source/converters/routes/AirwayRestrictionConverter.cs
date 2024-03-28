using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class AirwayRestrictionConverter : ICharConverter
{
    public static object Convert(char @char) => char.IsWhiteSpace(@char) ? AirwayRestriction.None : @char switch
    {
        'F' => AirwayRestriction.Forward,
        'B' => AirwayRestriction.Backward,
        _ => AirwayRestriction.Unknown
    };
}
