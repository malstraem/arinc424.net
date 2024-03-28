using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal class BoundaryCodeConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'U' => BoundaryCode.USA,
        'C' => BoundaryCode.CanadaAlaska,
        'P' => BoundaryCode.Pacific,
        'L' => BoundaryCode.LatinAmerica,
        'S' => BoundaryCode.SouthAmerica,
        '1' => BoundaryCode.SouthPacific,
        'E' => BoundaryCode.Europe,
        '2' => BoundaryCode.EasternEurope,
        'M' => BoundaryCode.MiddleEastSouthAsia,
        'A' => BoundaryCode.Africa,
        _ => BoundaryCode.Unknown
    };
}
