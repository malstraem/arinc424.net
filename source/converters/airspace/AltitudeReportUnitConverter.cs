using Arinc424.Airspace.Terms;
using Arinc424.Converters;

namespace Arinc424.Airspace;

internal class AltitudeReportUnitConverter : ICharConverter<AltitudeReportUnitConverter, AltitudeReportUnit>
{
    public static AltitudeReportUnit Convert(char @char) => @char switch
    {
        '0' => AltitudeReportUnit.NotSpecified,
        '1' => AltitudeReportUnit.Level,
        '2' => AltitudeReportUnit.Meters,
        '3' => AltitudeReportUnit.Feet,
        _ => AltitudeReportUnit.Unknown
    };
}
