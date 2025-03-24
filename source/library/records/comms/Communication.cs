namespace Arinc424.Comms;

[ContinuousAttribute(Start = Supplement.V19)]
public abstract class Communication<TTransmitter> : Record424<TTransmitter> where TTransmitter : Transmitter
{
    /// <inheritdoc cref="Terms.CommClass"/>
    [Field(16, 19, Start = Supplement.V19)]
    public Terms.CommClass Class { get; set; }
}
