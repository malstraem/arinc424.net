using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal abstract class OmnidirectionalCoverageConverter : ICharConverter<OmnidirectionalCoverageConverter, NavaidCoverage>
{
    public static NavaidCoverage Convert(char @char) => @char switch
    {
        'T' => NavaidCoverage.Terminal,
        'L' => NavaidCoverage.LowAltitude,
        'H' => NavaidCoverage.HighAltitude,
        'U' => NavaidCoverage.Undefined,
        'C' => NavaidCoverage.InstrumentLandingTactical,
        _ => NavaidCoverage.Unknown
    };
}
