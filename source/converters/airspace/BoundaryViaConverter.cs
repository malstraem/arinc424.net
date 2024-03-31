using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Converters;

/// <summary>
/// Converter for <see cref="BoundaryVia"/>.
/// </summary>
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
