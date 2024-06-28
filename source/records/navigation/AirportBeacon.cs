using Arinc424.Ports;

namespace Arinc424.Navigation;

/// <inheritdoc />
[Section('P', 'N')]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public class AirportBeacon : Nondirectional
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
