namespace Arinc424;

using Comms;
using Ground;
using Routing;
using Airspace;
using Navigation;

public abstract class Geo : Record424
{
    [Field(33, 51)]
    [Field<Tactical>(56, 74)]
    [Field<PathPoint>(38, 60)]
    [Field<RegionPoint>(35, 53)]
    [Field<SpecialArea>(24, 42)]
    [Field<GlobalLanding>(56, 74)]

    [Field<PortTransmitter>(33, 51)]
    [Field<AirwayTransmitter>(63, 81)]
    [Field<Transmitter>(93, 111, Start = Supplement.V19)]
    public Coordinates Coordinates { get; set; }
}
