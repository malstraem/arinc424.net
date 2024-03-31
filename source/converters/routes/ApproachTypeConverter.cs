using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

internal abstract class ApproachTypeConverter : ICharConverter<ApproachTypeConverter, ApproachType>
{
    public static ApproachType Convert(char @char) => @char switch
    {
        'A' => ApproachType.Transition,
        'B' => ApproachType.LocalizerBackCourse,
        'D' => ApproachType.DistanceEquipment,
        'F' => ApproachType.FlightManagement,
        'G' => ApproachType.InstrumentGuidance,
        'H' => ApproachType.AreaNavigationPerformance,
        'I' => ApproachType.InstrumentLanding,
        'J' => ApproachType.GlobalNavigationLanding,
        'L' => ApproachType.LocalizerOnly,
        'M' => ApproachType.MicrowaveLanding,
        'N' => ApproachType.NonDirectional,
        'P' => ApproachType.GlobalPositioning,
        'Q' => ApproachType.NonDirectionalDistanceEquipment,
        'R' => ApproachType.AreaNavigation,
        'S' => ApproachType.DistanceEquipmentTactical,
        'T' => ApproachType.Tactical,
        'U' => ApproachType.SimplifiedDirectionalFacility,
        'V' => ApproachType.Omnidirectional,
        'W' => ApproachType.TypeA,
        'X' => ApproachType.LocalizerDirectionalAid,
        'Y' => ApproachType.TypeBTypeC,
        'Z' => ApproachType.Missed,
        _ => ApproachType.Unknown
    };
}
