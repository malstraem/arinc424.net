using Arinc424.Ground;
using Arinc424.Processing;

namespace Arinc424.Procedures;

[Section('P', 'E', subsectionIndex: 13), Section('H', 'E', subsectionIndex: 13)]
[Pipeline<Sequence<ArrivalSequence, ArrivalPoint>>]
[Pipeline<IdentityWrap<Arrival, ArrivalSequence>>]
public class Arrival : Procedure<ArrivalSequence, ArrivalPoint>;

[Section('P', 'F', subsectionIndex: 13), Section('H', 'F', subsectionIndex: 13)]
[Pipeline<Sequence<ApproachSequence, ApproachPoint>>]
[Pipeline<IdentityWrap<Approach, ApproachSequence>>]
public class Approach : Procedure<ApproachSequence, ApproachPoint>
{
    [One]
    public GroundPoint? GroundPoint { get; set; }

    [One]
    public SatellitePoint? SatellitePoint { get; set; }
}

[Section('P', 'D', subsectionIndex: 13), Section('H', 'D', subsectionIndex: 13)]
[Pipeline<Sequence<DepartureSequence, DeparturePoint>>]
[Pipeline<IdentityWrap<Departure, DepartureSequence>>]
public class Departure : Procedure<DepartureSequence, DeparturePoint>;
