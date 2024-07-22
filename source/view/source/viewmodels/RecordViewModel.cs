namespace Arinc424.ViewModels;

public class RecordViewModel
{
    public RecordViewModel(Record424 record)
    {
        Record = record;

        if (record is IIcao icao)
            IcaoCode = icao.IcaoCode;

        if (record is IIdentity identity)
            Identifier = identity.Identifier;

        if (record is INamed named)
            Name = named.Name;
    }

    public Record424 Record { get; }

    public string? IcaoCode { get; }

    public string? Identifier { get; }

    public string? Name { get; }
}
