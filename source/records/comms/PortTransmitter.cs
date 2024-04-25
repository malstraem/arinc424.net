using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Comms;

public class PortTransmitter : Transmitter
{
    [Field(112, 114), Decode<PortCommUsagesConverter>]
    public Terms.PortCommUsages Usages { get; set; }
}
