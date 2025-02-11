namespace Arinc424.ViewModels;

public class RecordViewModel
{
    public RecordViewModel(Record424 record)
    {
        Record = record;

        if (record is IIcao icao)
            Icao = icao.Icao;

        if (record is IIdentity identity)
            Identifier = identity.Identifier;

        if (record is INamed named)
            Name = named.Name;
    }

    public Record424 Record { get; }

    public Icao? Icao { get; }

    public string? Name { get; }

    public string? Identifier { get; }
}
