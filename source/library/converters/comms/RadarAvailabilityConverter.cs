namespace Arinc424.Converters;

internal abstract class RadarAvailabilityConverter : ICharConverter<Bool>
{
    public static bool TryConvert(char @char, out Bool value)
    {
        switch (@char)
        {
            case (char)32:
                value = Bool.Unspecified; return true;
            case 'R':
                value = Bool.Yes; return true;
            case 'N':
                value = Bool.No; return true;
            default:
                value = Bool.Unknown; return false;
        }
    }
}
