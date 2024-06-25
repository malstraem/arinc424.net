using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// Sequence of <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'E', subsectionIndex: 13)]
[Process<AirportArrival, AirportArrivalSequence,
    ProcedureConcatenater<AirportArrival, AirportArrivalSequence, ArrivalPoint>>] // any more elegant way?
public class AirportArrivalSequence : ArrivalSequence;

/// <summary>
/// Sequence of <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'F', subsectionIndex: 13)]
[Process<AirportApproach, AirportApproachSequence,
    ProcedureConcatenater<AirportApproach, AirportApproachSequence, ApproachPoint>>]
public class AirportApproachSequence : ApproachSequence;

/// <summary>
/// Sequence of <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'D', subsectionIndex: 13)]
[Process<AirportDeparture, AirportDepartureSequence,
    ProcedureConcatenater<AirportDeparture, AirportDepartureSequence, DeparturePoint>>]
public class AirportDepartureSequence : DepartureSequence;

/// <summary>
/// Sequence of <c>Heliport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Obsolete("placeholder")]
[Section('H', 'E', subsectionIndex: 13)]
[Process<HeliportArrival, HeliportArrivalSequence,
    ProcedureConcatenater<HeliportArrival, HeliportArrivalSequence, ArrivalPoint>>]
public class HeliportArrivalSequence : ArrivalSequence
{

}

/// <summary>
/// Sequence of <c>Heliport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Obsolete("placeholder")]
[Section('H', 'F', subsectionIndex: 13)]
[Process<HeliportApproach, HeliportApproachSequence,
    ProcedureConcatenater<HeliportApproach, HeliportApproachSequence, ApproachPoint>>]
public class HeliportApproachSequence : ApproachSequence
{

}

/// <summary>
/// Sequence of <c>Heliport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Obsolete("placeholder")]
[Section('H', 'D', subsectionIndex: 13)]
[Process<HeliportDeparture, HeliportDepartureSequence,
    ProcedureConcatenater<HeliportDeparture, HeliportDepartureSequence, DeparturePoint>>]
public class HeliportDepartureSequence : DepartureSequence
{

}
