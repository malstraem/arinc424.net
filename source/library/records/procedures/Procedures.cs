namespace Arinc424.Procedures;

using Processing;
using Ground;

/**<summary>
Multiple <c>Airport</c> and <c>Heliport STAR</c>
primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'E', subInd: 13), Section('H', 'E', subInd: 13)]

[Pipe<IdentityWrap<Arrival, ArrivalSequence>>]
public class Arrival : Procedure<ArrivalSequence, ArrivalPoint>;

/**<summary>
Multiple <c>Airport</c> and <c>Heliport Approach</c>
primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'F', subInd: 13), Section('H', 'F', subInd: 13)]

[Pipe<IdentityWrap<Approach, ApproachSequence>>]
public class Approach : Procedure<ApproachSequence, ApproachPoint>
{
    [Many(nameof(PathPoint.Approach))]
    public GroundPoint[]? GroundPoints { get; set; }

    [Many(nameof(PathPoint.Approach))]
    public SatellitePoint[]? SatellitePoints { get; set; }
}

/**<summary>
Multiple <c>Airport</c> and <c>Heliport SID</c>
primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'D', subInd: 13), Section('H', 'D', subInd: 13)]

[Pipe<IdentityWrap<Departure, DepartureSequence>>]
public class Departure : Procedure<DepartureSequence, DeparturePoint>;
