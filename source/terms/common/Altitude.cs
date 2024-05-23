namespace Arinc424;

[Decode<AltitudeConverter>]
[DebuggerDisplay($"{{{nameof(Value)}}}, {{{nameof(Unit)}}}")]
public readonly struct Altitude(int value, AltitudeUnit unit)
{
    public int Value { get; } = value;

    public AltitudeUnit Unit { get; } = unit;
}
