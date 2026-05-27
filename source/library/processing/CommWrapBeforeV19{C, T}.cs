namespace Arinc424.Processing;

using Comms;

internal sealed class CommWrapBeforeV19<C, T>(Supplement supplement)
    : Wrap<C, T>(supplement)
        where C : Communication<T>, new()
        where T : Transmitter
{
    /// <summary><see cref="IIdentity.Identifier"/> range.</summary>
    private readonly Range range = 6..10;

    protected override bool Trigger(T current, T next)
        => current.Source![range] != next.Source![range];
}
