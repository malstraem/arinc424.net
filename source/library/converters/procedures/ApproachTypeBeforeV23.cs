using Arinc424.Procedures.Terms;

namespace Arinc424.Converters;

using static ApproachTypes;

/**<summary>
Supplement 23 introduce breaking changes by replacing the meaning of 'Y'.
</summary>*/
internal class ApproachTypesBeforeV23 : ICharConverter<ApproachTypes>
{
    public static bool TryConvert(char @char, out ApproachTypes value)
    {
        switch (@char)
        {
            case (char)32:
                value = Unknown; return true;
            case 'A':
                value = Transition; return true;
            case 'L':
                value = Localizer; return true;
            case 'B':
                value = Localizer | Backcourse; return true;
            case 'X':
                value = Localizer | Directional; return true;
            case 'N':
                value = Nondirect; return true;
            case 'Q':
                value = Nondirect | Equipment; return true;
            case 'V':
                value = Omnidirect; return true;
            case 'D':
                value = Omnidirect | Equipment; return true;
            case 'S':
                value = Omnidirect | Equipment | Tactical; return true;
            case 'T':
                value = Tactical; return true;
            case 'F':
                value = FlightManagement; return true;
            case 'G':
                value = InstrumentGuidance; return true;
            case 'I':
                value = InstrumentLanding; return true;
            case 'J':
                value = GlobalLanding; return true;
            case 'M':
                value = MicrowaveLanding; return true;
            case 'P':
                value = GlobalPosition; return true;
            case 'R':
                value = AreaNavigation; return true;
            case 'H':
                value = AreaNavigation | Performance; return true;
            case 'U':
                value = Directional; return true;
            case 'W':
                value = TypeA; return true;
            case 'Y':
                value = TypeB | TypeC; return true;
            case 'Z':
                value = Missed; return true;
            default:
                value = Unknown; return false;
        }
    }
}
