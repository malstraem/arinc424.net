using Arinc424.Attributes;
using Arinc424.Ports;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <inheritdoc />
[Section('P', 'N')]
public class AirportBeacon : NondirectionalBeacon
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
