namespace Arinc424.Airspace;

public class Space<TVolume> : Record424<TVolume>, IIcao, INamed where TVolume : Volume
{
    public string IcaoCode { get; set; }

    public string? Name { get; set; }
}
