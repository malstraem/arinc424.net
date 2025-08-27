namespace Arinc424.Model;

public class RecordModel(Record424 record)
{
    private readonly Record424 record = record;

    public Record424 Record => record;

    public Icao? Icao => record is IIcao icao ? icao.Icao : null;

    public string? Name => record is INamed named ? named.Name : null;

    public string? Identifier => record is IIdentity identity ? identity.Identifier : null;
}
