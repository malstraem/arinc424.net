namespace Arinc.Spec424.Terms.Converters;

/// <summary>
/// Converter for <see cref="BoundaryVia"/>.
/// </summary>
internal class BoundaryViaConverter : ICharConverter
{
    public static object Convert(char @char) => @char switch
    {
        'C' => BoundaryVia.Circle,
        'G' => BoundaryVia.GreatCircle,
        'H' => BoundaryVia.RhumbLine,
        'L' => BoundaryVia.CounterClockwiseArc,
        'R' => BoundaryVia.ClockwiseArc,
        _ => throw new NotSupportedException($"Char '{@char}' is not supported")
    };
}
