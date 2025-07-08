namespace Arinc424.Navigation;

/// <inheritdoc />
[Section('P', 'N'), Port(7, 10)]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public class TerminalBeacon : Nondirect
{
    [Identifier(7, 10)]
    public Ground.Port Port { get; set; }
}
