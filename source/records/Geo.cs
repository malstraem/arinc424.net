using Arinc424.Airspace;
using Arinc424.Comms;
using Arinc424.Navigation;
using Arinc424.Ports;
using Arinc424.Routing;

namespace Arinc424;

public abstract class Geo : Record424
{
    [Field(33, 51)]
    [Field<Transmitter>(93, 111)]
    [Field<FlightRegionPoint>(35, 53)]
    [Field<GlobalLandingSystem>(56, 74)]
    [Field<SpecialActivityArea>(24, 42)]
    [Field<AirportSatellitePoint>(38, 60)]
    public Coordinates Coordinates { get; set; }
}
