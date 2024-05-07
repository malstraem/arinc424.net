using Arinc424.Airspace.Terms;

namespace Arinc424.Converters;

internal abstract class BoundaryViaConverter : ICharConverter<BoundaryViaConverter, BoundaryVia>
{
    public static BoundaryVia Convert(char @char) => @char switch
    {
        'C' => BoundaryVia.Circle,
        'G' => BoundaryVia.GreatCircle,
        'H' => BoundaryVia.RhumbLine,
        'L' => BoundaryVia.CounterClockwiseArc,
        'R' => BoundaryVia.ClockwiseArc,
        _ => BoundaryVia.Unknown
    };
}
