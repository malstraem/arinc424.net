using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <inheritdoc />
[Record('P', 'N')]
public class AirportBeacon : NonDirectionalBeacon
{
    [Foreign(7, 12), Primary]
    public Airport Airport { get; set; }
}
