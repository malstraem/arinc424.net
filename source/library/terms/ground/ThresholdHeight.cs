namespace Arinc424.Ground.Terms;

/// <summary>
/// <c>Path Point TCH</c> and <c>TCH Units Indicator</c> fields.
/// </summary>
/// <remarks>See section 5.265 and 5.266.</remarks>
[Decode<ThresholdHeightConverter, ThresholdHeight>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Unit)}}}")]
public readonly struct ThresholdHeight(float value, AltitudeUnit unit)
{
    public float Value { get; } = value;

    public AltitudeUnit Unit { get; } = unit;
}
