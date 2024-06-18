namespace Arinc424.Procedures;

/// <summary>
/// <c>Airport Approach</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'F', subsectionIndex: 13)]
public class AirportApproachSequence : ApproachSequence;

/// <summary>
/// <c>Airport SID</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>

[Section('P', 'D', subsectionIndex: 13)]
public class AirportDepartureSequence : DepartureSequence;

/// <summary>
/// <c>Airport STAR</c> primary record.
/// </summary>
/// <remarks>See section 4.1.9.1.</remarks>
[Section('P', 'E', subsectionIndex: 13)]
public class AirportArrivalSequence : ArrivalSequence;
