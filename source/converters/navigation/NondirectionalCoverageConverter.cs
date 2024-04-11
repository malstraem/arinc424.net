using Arinc424.Navigation.Terms;

namespace Arinc424.Converters;

internal class NondirectionalCoverageConverter : ICharConverter<NondirectionalCoverageConverter, NavaidCoverage>
{
    public static NavaidCoverage Convert(char @char) => char.IsWhiteSpace(@char) ? NavaidCoverage.Default : @char switch
    {
        'H' => NavaidCoverage.HighPowered,
        'M' => NavaidCoverage.LowPowered,
        'L' => NavaidCoverage.Locator,
        _ => NavaidCoverage.Unknown
    };
}
