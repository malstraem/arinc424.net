using Arinc424.Procedures;

namespace Arinc424.Ports;

/// <summary>
/// <c>GBAS Path Point</c> primary record.
/// </summary>
/// <remarks>See section 4.1.35.1.</remarks>
[Section('P', 'Q', subsectionIndex: 13)]
public class GroundPoint : PathPoint
{
    [Foreign(7, 12)]
    public Airport Airport { get; set; }

    [Foreign(7, 12), Foreign(14, 19), Foreign(11, 12)]
    public AirportApproach Approach { get; set; }

    [Foreign(7, 12), Foreign(20, 24), Foreign(11, 12)]
    public Runway Runway { get; set; }
}
