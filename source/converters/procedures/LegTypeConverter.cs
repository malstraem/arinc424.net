using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal abstract class LegTypeConverter : IStringConverter<LegTypeConverter, LegType>
{
    public static LegType Convert(ReadOnlySpan<char> @string) => @string switch
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