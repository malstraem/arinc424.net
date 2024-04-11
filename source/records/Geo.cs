using Arinc424.Airspace;
using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424;

public abstract class Geo : Record424
{
    [Decode<CoordinatesConverter>]
    [Field(33, 51), Field<FlightInfoRegion>(35, 53)]
    public Coordinates Coordinates { get; set; }
}
