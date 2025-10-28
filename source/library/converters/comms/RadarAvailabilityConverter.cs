namespace Arinc424.Converters;

using static Bool;

internal abstract class RadarAvailabilityConverter : ICharConverter<Bool>
{
    public static bool TryConvert(char @char, out Bool value)
    {
        switch (@char)
        {
            case 'R':
                value = Yes; return true;
            case 'N':
                value = No; return true;
            case 'U' or (char)32:
                value = Unspecified; return true;
            default:
                value = Unknown; return false;
        }
    }
}
