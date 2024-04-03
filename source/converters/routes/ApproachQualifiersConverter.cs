using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

internal abstract class ApproachQualifiersConverter : IStringConverter<ApproachQualifiersConverter, ApproachQualifiers>
{
    public static ApproachQualifiers Convert(ReadOnlySpan<char> @string) => @string[0] switch
    {
        'B' => ApproachQualifiers.AreaNavigationVisual,
        'D' => ApproachQualifiers.DistanceEquipment,
        'J' => ApproachQualifiers.DistanceEquipmentNotAuthorized,
        'F' => ApproachQualifiers.NavigationPerformance,
        'A' => ApproachQualifiers.Advanced,
        'L' => ApproachQualifiers.GroundBasedAugmentation,
        'N' => ApproachQualifiers.DistanceEquipmentNotRequired,
        'P' => ApproachQualifiers.GlobalNavigation,
        'R' => ApproachQualifiers.GlobalNavigationDistanceEquipment,
        'T' => ApproachQualifiers.AreaNavigationDistanceEquipment,
        'U' => ApproachQualifiers.SensorNotSpecified,
        'V' => ApproachQualifiers.AreaNavigation,
        'W' => ApproachQualifiers.FinalApproachSegmentDataBlock,
        _ => ApproachQualifiers.Unknown
    }
    | @string[1] switch
    {
        'A' => ApproachQualifiers.PrimaryMissed,
        'B' => ApproachQualifiers.SecondaryMissed,
        'E' => ApproachQualifiers.EngineOutMissed,
        'C' => ApproachQualifiers.CircleToLand,
        'H' => ApproachQualifiers.HelicopterStraightIn,
        'I' => ApproachQualifiers.HelicopterCircleToLand,
        'L' => ApproachQualifiers.HelicopterLanding,
        'S' => ApproachQualifiers.StraightIn,
        'V' => ApproachQualifiers.VisualMeteoConditions,
        _ => ApproachQualifiers.Unknown
    };
}
