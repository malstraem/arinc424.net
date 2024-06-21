using Arinc424.Processing;

namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'F', subsectionIndex: 13)]
[Process<AirportApproach, AirportApproachSequence,
    ProcedureConcatenater<AirportApproach, AirportApproachSequence, ApproachPoint>>] // any more elegant way?
public class AirportApproachSequence : ApproachSequence;

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'D', subsectionIndex: 13)]
[Process<AirportDeparture, AirportDepartureSequence,
    ProcedureConcatenater<AirportDeparture, AirportDepartureSequence, DeparturePoint>>]
public class AirportDepartureSequence : DepartureSequence;

/// <summary>
/// <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'E', subsectionIndex: 13)]
[Process<AirportArrival, AirportArrivalSequence,
    ProcedureConcatenater<AirportArrival, AirportArrivalSequence, ArrivalPoint>>]
public class AirportArrivalSequence : ArrivalSequence;
