using Arinc424.Routing.Terms;

namespace Arinc424.Converters;

internal abstract class BoundaryCodeConverter : ICharConverter<BoundaryCodeConverter, BoundaryCode>
{
    public static BoundaryCode Convert(char @char) => @char switch
    {
        'U' => BoundaryCode.UnitedStates,
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
