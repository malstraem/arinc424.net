using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="BoundaryCode"/>.
/// </summary>
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