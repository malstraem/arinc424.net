namespace Arinc424.Ground;

[Obsolete("todo: describe supplement v21+")]
public class Helipad : Fix, IIcao
{
    public Heliport Heliport { get; set; }

    public string Icao { get; set; }
}
