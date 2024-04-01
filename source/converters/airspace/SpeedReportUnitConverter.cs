using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class SpeedReportUnitConverter : ICharConverter<SpeedReportUnitConverter, SpeedReportUnit>
{
    public static SpeedReportUnit Convert(char @char) => @char switch
    {
        '0' => SpeedReportUnit.NotSpecified,
        '1' => SpeedReportUnit.Knots,
        '2' => SpeedReportUnit.Mach,
        '3' => SpeedReportUnit.KilometersPerHour,
        _ => SpeedReportUnit.Unknown
    };
}
