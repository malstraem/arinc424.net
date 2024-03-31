using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="LegType"/>.
/// </summary>
internal abstract class LegTypeConverter : IStringConverter<LegTypeConverter, LegType>
{
    public static LegType Convert(string @string) => @string switch
    {
        "IF" => LegType.Initial,
        "TF" => LegType.TrackToFix,
        "CF" => LegType.CourseToFix,
        "DF" => LegType.DirectToFix,
        "FA" => LegType.FixToAltitude,
        "FC" => LegType.FromFixToDistance,
        "FD" => LegType.FromFixToDme,
        "FM" => LegType.FromFixToManual,
        "CA" => LegType.CourseToAltitude,
        "CD" => LegType.CourseToDme,
        "CI" => LegType.CourseToIntercept,
        "CR" => LegType.CourseToRadial,
        "RF" => LegType.ConstantRadiusArc,
        "AF" => LegType.ArcToFix,
        "VA" => LegType.HeadingToAltitude,
        "VD" => LegType.HeadingToDme,
        "VI" => LegType.HeadingToIntercept,
        "VM" => LegType.HeadingToManual,
        "VR" => LegType.HeadingToRadial,
        "PI" => LegType.Turn,
        "HA" => LegType.AltitudeTermination,
        "HF" => LegType.SingleCircuitTermination,
        "HM" => LegType.ManualTermination,
        _ => LegType.Unknown
    };
}
