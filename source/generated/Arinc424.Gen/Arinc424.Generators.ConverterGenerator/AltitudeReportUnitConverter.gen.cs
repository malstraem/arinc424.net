using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class AltitudeReportUnitConverter : ICharConverter<AltitudeReportUnitConverter, AltitudeReportUnit>
{
    public static AltitudeReportUnit Convert(char @char) => @char switch
    {
        '0' => AltitudeReportUnit.Unspecified,
        '1' => AltitudeReportUnit.Level,
        '2' => AltitudeReportUnit.Meters,
        '3' => AltitudeReportUnit.Feet,
        _ => AltitudeReportUnit.Unknown
    };
}
