using Arinc424.Ground;
using Arinc424.Processing;

namespace Arinc424.Procedures;

/**<summary>
Multiple <c>Airport and Heliport STAR</c> primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'E', subIndex: 13), Section('H', 'E', subIndex: 13)]

[Pipeline<IdentityWrap<Arrival, ArrivalSequence>>]
public class Arrival : Procedure<ArrivalSequence, ArrivalPoint>;

/**<summary>
Multiple <c>Airport and Heliport Approach</c> primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'F', subIndex: 13), Section('H', 'F', subIndex: 13)]

[Pipeline<IdentityWrap<Approach, ApproachSequence>>]
public class Approach : Procedure<ApproachSequence, ApproachPoint>
{
    [Many]
    public GroundPoint[]? GroundPoints { get; set; }

    [Many]
    public SatellitePoint[]? SatellitePoints { get; set; }
}

/**<summary>
Multiple <c>Airport and Heliport SID</c> primary record sequences under same identifier.
</summary>
<remarks>See section 4.1.9.1 and 4.2.3.1.</remarks>*/
[Section('P', 'D', subIndex: 13), Section('H', 'D', subIndex: 13)]

[Pipeline<IdentityWrap<Departure, DepartureSequence>>]
public class Departure : Procedure<DepartureSequence, DeparturePoint>;
