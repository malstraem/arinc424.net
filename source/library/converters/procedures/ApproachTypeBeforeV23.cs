namespace Arinc424.Converters;

using Procedures.Terms;

/**<summary>
Supplement 23 introduce breaking changes by replacing the meaning of 'Y'.
</summary>*/
internal class ApproachTypeBeforeV23 : ICharConverter<ApproachType>
{
    public static bool TryConvert(char @char, out ApproachType value)
    {
        switch (@char)
        {
            case (char)32:
                value = ApproachType.Unknown; return true;
            case 'A':
                value = ApproachType.Transition; return true;
            case 'B':
                value = ApproachType.BackCourse; return true;
            case 'D':
                value = ApproachType.DistanceEquipment; return true;
            case 'F':
                value = ApproachType.FlightManagement; return true;
            case 'G':
                value = ApproachType.InstrumentGuidance; return true;
            case 'H':
                value = ApproachType.Performance; return true;
            case 'I':
                value = ApproachType.InstrumentLanding; return true;
            case 'J':
                value = ApproachType.GlobalLanding; return true;
            case 'L':
                value = ApproachType.LocalizerOnly; return true;
            case 'M':
                value = ApproachType.MicrowaveLanding; return true;
            case 'N':
                value = ApproachType.Nondirectional; return true;
            case 'P':
                value = ApproachType.GlobalPositioning; return true;
            case 'Q':
                value = ApproachType.NondirectDistanceEquipment; return true;
            case 'R':
                value = ApproachType.AreaNavigation; return true;
            case 'S':
                value = ApproachType.DistanceEquipmentTactical; return true;
            case 'T':
                value = ApproachType.Tactical; return true;
            case 'U':
                value = ApproachType.Simplified; return true;
            case 'V':
                value = ApproachType.Omnidirectional; return true;
            case 'W':
                value = ApproachType.Alpha; return true;
            case 'X':
                value = ApproachType.Directional; return true;
            case 'Y':
                value = ApproachType.BasedConstruction; return true;
            case 'Z':
                value = ApproachType.Missed; return true;
            default:
                value = ApproachType.Unknown; return false;
        }
    }
}
