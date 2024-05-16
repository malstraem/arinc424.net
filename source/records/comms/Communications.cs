namespace Arinc424.Comms;

[Sequenced(20, 21), Continuous]
public abstract class Communications<TTransmitter> : Record424<TTransmitter> where TTransmitter : Transmitter
{
    /// <inheritdoc cref="Terms.CommClass"/>
    [Field(16, 19), Decode<CommClassConverter>]
    public Terms.CommClass Class { get; set; }
}
