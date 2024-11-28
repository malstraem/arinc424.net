using System.Runtime.CompilerServices;

using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class RegionTypeConverter : ICharConverter<RegionType>
{
    public static bool TryConvert(char @char, out RegionType value)
    {
        switch (@char)
        {
            case (char)32:
                value = RegionType.Unknown; return true;
            case 'F':
                value = RegionType.Flight; return true;
            case 'U':
                value = RegionType.Upper; return true;
            case 'B':
                value = RegionType.Flight | RegionType.Upper; return true;
            default:
                value = RegionType.Unknown; return false;
        }
    }
}
