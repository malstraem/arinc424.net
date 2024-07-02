using Arinc424.Ports;

namespace Arinc424.Navigation;

/// <inheritdoc />
[Section('P', 'N')]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class TerminalBeacon : Nondirectional
{
    [Foreign(7, 12), Primary]

    [Identifier(7, 10), Icao(11, 12)]
    public Airport Airport { get; set; }
}
