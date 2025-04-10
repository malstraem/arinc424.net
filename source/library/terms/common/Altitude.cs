namespace Arinc424;

/**<summary>
Various altitudes according to the specification.
</summary>*/
[Decode<AltitudeConverter, Altitude>]
[Decode<ThresholdHeightConverter, Altitude, Ground.PathPoint>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Unit)}}}")]
public readonly struct Altitude(float value, AltitudeUnit unit)
{
    public float Value { get; } = value;

    public AltitudeUnit Unit { get; } = unit;

    public static Altitude operator *(Altitude left, int right) => new(left.Value * right, left.Unit);
}
