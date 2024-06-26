using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport STAR</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'E', subsectionIndex: 13)]
[Process<AirportArrival, AirportArrivalSequence,
    ProcedureConcatenater<AirportArrival, AirportArrivalSequence, ArrivalPoint>>] // any more elegant way?
public class AirportArrivalSequence : ArrivalSequence;

/// <summary>
/// <c>Airport Approach</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'F', subsectionIndex: 13)]
[Process<AirportApproach, AirportApproachSequence,
    ProcedureConcatenater<AirportApproach, AirportApproachSequence, ApproachPoint>>]
public class AirportApproachSequence : ApproachSequence;

/// <summary>
/// <c>Airport SID</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'D', subsectionIndex: 13)]
[Process<AirportDeparture, AirportDepartureSequence,
    ProcedureConcatenater<AirportDeparture, AirportDepartureSequence, DeparturePoint>>]
public class AirportDepartureSequence : DepartureSequence;

/// <summary>
/// <c>Heliport STAR</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Section('H', 'E', subsectionIndex: 13)]
[Process<HeliportArrival, HeliportArrivalSequence,
    ProcedureConcatenater<HeliportArrival, HeliportArrivalSequence, ArrivalPoint>>]
public class HeliportArrivalSequence : ArrivalSequence;

/// <summary>
/// <c>Heliport Approach</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Section('H', 'F', subsectionIndex: 13)]
[Process<HeliportApproach, HeliportApproachSequence,
    ProcedureConcatenater<HeliportApproach, HeliportApproachSequence, ApproachPoint>>]
public class HeliportApproachSequence : ApproachSequence;

/// <summary>
/// <c>Heliport SID</c> primary record sequence.
/// </summary>
/// <remarks>See section 4.2.3.1.</remarks>
[Section('H', 'D', subsectionIndex: 13)]
[Process<HeliportDeparture, HeliportDepartureSequence,
    ProcedureConcatenater<HeliportDeparture, HeliportDepartureSequence, DeparturePoint>>]
public class HeliportDepartureSequence : DepartureSequence;
