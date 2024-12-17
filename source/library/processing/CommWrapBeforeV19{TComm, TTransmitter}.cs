using Arinc424.Comms;

namespace Arinc424.Processing;

internal sealed class CommWrapBeforeV19<TComm, TTransmitter>(Supplement supplement) : Wrap<TComm, TTransmitter>(supplement)
    where TComm : Communication<TTransmitter>, new()
    where TTransmitter : Transmitter
{
    /// <summary>
    /// <see cref="IIdentity.Identifier"/> range.
    /// </summary>
    private readonly Range range = 6..10;

    protected override bool Trigger(TTransmitter current, TTransmitter next) => current.Source![range] != next.Source![range];
}
