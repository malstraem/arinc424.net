using Arinc424.Attributes;
using Arinc424.Ports;

namespace Arinc424.Navigation;

#pragma warning disable CS8618

/// <inheritdoc />
[Record('P', 'N')]
public class AirportBeacon : NonDirectionalBeacon
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
