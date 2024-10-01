namespace Arinc424.Ground;

/// <summary>
/// <c>Helipad</c> primary record.
/// </summary>
[Obsolete("todo: describe supplement v21+")]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public class Helipad : Fix, IIcao
{
    public string Icao { get; set; }

    public Heliport Heliport { get; set; }
}
