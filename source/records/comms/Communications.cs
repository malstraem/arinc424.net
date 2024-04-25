using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Comms;

[Sequenced(20, 21), Continuous]
public abstract class Communications<TTransmitter> : Record424<TTransmitter> where TTransmitter : Transmitter
{
    [Field(16, 19), Decode<CommClassConverter>]
    public Terms.CommClass Type { get; set; }
}
