namespace Arinc424;

public struct Altitude(int value, AltitudeUnit unit)
{
    public int Value { get; set; } = value;

    public AltitudeUnit Unit { get; set; } = unit;
}
