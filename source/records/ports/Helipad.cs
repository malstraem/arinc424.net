namespace Arinc424.Ports;

[Obsolete("todo: describe supplement v21+")]
public class Helipad : Fix, IIcao
{
    public Heliport Heliport { get; set; }

    public string IcaoCode { get; set; }
}
