using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="AircraftTypes"/>.
/// </summary>
internal class AircraftTypesConverter : ICharConverter<AircraftTypesConverter, AircraftTypes>
{
    public static AircraftTypes Convert(char @char) => @char switch
    {
        'A' => AircraftTypes.CategoryA,
        'B' => AircraftTypes.CategoryB,
        'C' => AircraftTypes.CategoryC,
        'D' => AircraftTypes.CategoryD,
        'E' => AircraftTypes.CategoryE,
        'F' => AircraftTypes.CategoryA | AircraftTypes.CategoryB,
        'G' => AircraftTypes.CategoryC | AircraftTypes.CategoryD,
        'I' => AircraftTypes.CategoryA | AircraftTypes.CategoryB | AircraftTypes.CategoryC,
        'J' => AircraftTypes.CategoryA | AircraftTypes.CategoryB | AircraftTypes.CategoryC | AircraftTypes.CategoryD,
        'K' => AircraftTypes.CategoryA | AircraftTypes.CategoryB | AircraftTypes.CategoryC | AircraftTypes.CategoryD | AircraftTypes.CategoryE,
        'L' => AircraftTypes.CategoryD | AircraftTypes.CategoryE,
        'H' => AircraftTypes.Helicopter,
        'P' => AircraftTypes.NotLimited,
        'R' => AircraftTypes.Turbojet,
        'S' => AircraftTypes.Turboprop,
        'T' => AircraftTypes.Prop,
        'U' => AircraftTypes.Turboprop | AircraftTypes.Prop,
        _ => AircraftTypes.Unknown
    };
}