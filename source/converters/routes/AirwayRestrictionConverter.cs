using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="AirwayRestriction"/>.
/// </summary>
internal abstract class AirwayRestrictionConverter : ICharConverter<AirwayRestrictionConverter, AirwayRestriction>
{
    public static AirwayRestriction Convert(char @char) => char.IsWhiteSpace(@char) ? AirwayRestriction.None : @char switch
    {
        'F' => AirwayRestriction.Forward,
        'B' => AirwayRestriction.Backward,
        _ => AirwayRestriction.Unknown
    };
}