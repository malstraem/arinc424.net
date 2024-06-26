namespace Arinc424.Ports;

/// <summary>
/// <c>Heliport MSA</c> primary record.
/// </summary>
/// <remarks>See section 4.2.4.1.</remarks>
[Section('H', 'S', subsectionIndex: 13)]
public class HeliportMinimumAltitude : MinimumAltitude
{
    [Foreign(7, 12)]
    public Heliport Heliport { get; set; }
}
