using Arinc424.Airspace;
using Arinc424.Attributes;
using Arinc424.Comms;
using Arinc424.Converters;
using Arinc424.Navigation;

namespace Arinc424;

public abstract class Geo : Record424
{
    [Field(33, 51), Decode<CoordinatesConverter>]
    [Field<Transmitter>(93, 111)]
    [Field<FlightRegionPoint>(35, 53)]
    [Field<GlobalLandingSystem>(56, 74)]
    public Coordinates Coordinates { get; set; }
}
