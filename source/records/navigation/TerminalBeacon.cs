using Arinc424.Ports;

namespace Arinc424.Navigation;

/// <inheritdoc />
[Section('P', 'N'), Port(7, 10)]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class TerminalBeacon : Nondirectional
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }
}
