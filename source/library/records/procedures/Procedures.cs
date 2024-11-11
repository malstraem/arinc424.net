using Arinc424.Ground;
using Arinc424.Processing;

namespace Arinc424.Procedures;

[Section('P', 'E', subsectionIndex: 13), Section('H', 'E', subsectionIndex: 13)]
[Pipeline<Sequence<ArrivalSequence, ArrivalPoint>, ArrivalPoint>]
[Pipeline<IdentityWrap<Arrival, ArrivalSequence>, ArrivalSequence>]
public class Arrival : Procedure<ArrivalSequence, ArrivalPoint>;

[Section('P', 'F', subsectionIndex: 13), Section('H', 'F', subsectionIndex: 13)]
[Pipeline<Sequence<ApproachSequence, ApproachPoint>, ApproachPoint>]
[Pipeline<IdentityWrap<Approach, ApproachSequence>, ApproachSequence>]
public class Approach : Procedure<ApproachSequence, ApproachPoint>
{
    [One]
    public GroundPoint? GroundPoint { get; set; }

    [One]
    public SatellitePoint? SatellitePoint { get; set; }
}

[Section('P', 'D', subsectionIndex: 13), Section('H', 'D', subsectionIndex: 13)]
[Pipeline<Sequence<DepartureSequence, DeparturePoint>, DeparturePoint>]
[Pipeline<IdentityWrap<Departure, DepartureSequence>, DepartureSequence>]
public class Departure : Procedure<DepartureSequence, DeparturePoint>;
