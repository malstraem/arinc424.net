using Arinc424.Comms.Terms;

namespace Arinc424.Converters;

internal abstract class EmissionConverter : ICharConverter<EmissionConverter, Emission>
{
    public static Emission Convert(char @char) => @char switch
    {
        '3' => Emission.Double,
        'A' => Emission.SingleReducedCarrier,
        'B' => Emission.TwoIndependent,
        'H' => Emission.SingleFullCarrier,
        'J' => Emission.SingleSuppressedCarrier,
        'L' => Emission.LowerUnknownCarrier,
        'U' => Emission.UpperUnknownCarrier,
        _ => Emission.Unknown
    };
}
