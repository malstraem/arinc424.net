using Arinc424.Attributes;

namespace Arinc424.Comms;

public class AirwayTransmitter : Transmitter
{
    [Field(68, 92)]
    public string? Narrative { get; set; }

    [Field(112, 114), Obsolete("todo")]
    public string Usages { get; set; }
}
