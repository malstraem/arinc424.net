namespace Arinc424;

[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Unit)}}}")]
public struct Altitude(int value, AltitudeUnit unit)
{
    public int Value { get; set; } = value;

    public AltitudeUnit Unit { get; set; } = unit;
}
