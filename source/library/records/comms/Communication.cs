namespace Arinc424.Comms;

[Sequenced(20, 21, Supplement.V19), Continuous(supplement: Supplement.V19)]
public abstract class Communication<TTransmitter> : Record424<TTransmitter> where TTransmitter : Transmitter
{
    /// <inheritdoc cref="Terms.CommClass"/>
    [Field(16, 19, Supplement.V19)]
    public Terms.CommClass Class { get; set; }
}
