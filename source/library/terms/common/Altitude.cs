namespace Arinc424;

/// <summary>
/// Various altitudes according to the specification.
/// </summary>
[Decode<AltitudeConverter, Altitude>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Unit)}}}")]
public readonly struct Altitude(int value, AltitudeUnit unit)
{
    public int Value { get; } = value;

    public AltitudeUnit Unit { get; } = unit;

    public static Altitude operator *(Altitude left, int right) => new(left.Value * right, left.Unit);
}
