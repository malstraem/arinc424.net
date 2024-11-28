namespace Arinc424.Airspace;

[Continuous(25)]
public abstract class Space<TVolume> : Record424<TVolume>, IIcao where TVolume : Volume
{
    [Field(7, 8)]
    public string Icao { get; set; }
}
