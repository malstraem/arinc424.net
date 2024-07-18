using Arinc424.Ports;

namespace Arinc424.Procedures;

[Section('P', 'E', subsectionIndex: 13)]
[Section('H', 'E', subsectionIndex: 13)]
public class Arrival : Procedure<ArrivalSequence, ArrivalPoint>;

[Section('P', 'F', subsectionIndex: 13)]
[Section('H', 'F', subsectionIndex: 13)]
public class Approach : Procedure<ApproachSequence, ApproachPoint>
{
    [One]
    public PathPoint? GroundPathPoint { get; set; }

    [One]
    public SatellitePoint? SatellitePoint { get; set; }
}

[Section('P', 'D', subsectionIndex: 13)]
[Section('H', 'D', subsectionIndex: 13)]
public class Departure : Procedure<DepartureSequence, DeparturePoint>;
