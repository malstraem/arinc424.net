using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Flight Planning</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.27.1.</remarks>
[Record('P', 'R', subsectionIndex: 13), Continuation(70)]
public record FlightPlanning : Record424
{
    [Field(7, 10)]
    public required string AirportIdentifier { get; init; }

    [Field(11, 12)]
    public required string IcaoCode { get; init; }

    [Field(14, 19)]
    public required string ProcedureIdentifier { get; init; }

    [Character(20)]
    public required char ProcedureType { get; init; }

    [Field(21, 25)]
    public required string RunwayTransitionIdentifier { get; init; }

    [Field(26, 30)]
    public required string RunwayTransitionFix { get; init; }

    [Field(31, 32)]
    public required string RunwayTransitionFixIcaoCode { get; init; }

    [Character(33)]
    public required char RunwayTransitionFixSectionCode { get; init; }

    [Character(34)]
    public required char FixSubsectionCode { get; init; }

    [Field(35, 37)]
    public required string RunwayTransitionAlongTrackDistance { get; init; }

    [Field(38, 42)]
    public required string CommonSegmentTransitionFix { get; init; }

    [Field(43, 44)]
    public required string CommonSegmentTransitionFixIcaoCode { get; init; }

    [Character(45)]
    public required char CommonSegmentTransitionFixSectionCode { get; init; }

    [Character(46)]
    public required char CommonSegmentTransitionFixSubsectionCode { get; init; }

    [Field(47, 49)]
    public required string CommonSegmentAlongTrackDistance { get; init; }

    [Field(50, 54)]
    public required string EnrouteTransitionIdentifier { get; init; }

    [Field(55, 59)]
    public required string EnrouteTransitionFix { get; init; }

    [Field(60, 61)]
    public required string EnrouteTransitionFixIcaoCode { get; init; }

    [Character(62)]
    public required char EnrouteTransitionFixSectionCode { get; init; }

    [Character(63)]
    public required char EnrouteTransitionFixSubsectionCode { get; init; }

    [Field(64, 66)]
    public required string EnrouteTransitionAlongTrackDistance { get; init; }

    [Field(67, 69)]
    public required string SequenceNumber { get; init; }

    [Character(70)]
    public required char ContinuationRecordNumber { get; init; }

    [Field(71, 74)]
    public required string EnginesNumber { get; init; }

    /// <summary>
    /// <c>Turboprop/Jet Indicator (TURBO)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.233.</remarks>
    [Character(75)]
    public required char EngineTypeRestriction { get; init; }

    [Character(76)]
    public required char IsRnav { get; init; }

    [Character(77)]
    public required char AtcWeightCategory { get; init; }

    [Field(78, 84)]
    public required string AtcIdentifier { get; init; }

    [Character(85)]
    public required char TimeCode { get; init; }

    [Field(86, 100)]
    public required string ProcedureDescription { get; init; }

    [Field(101, 102)]
    public required string LegTypeCode { get; init; }

    [Character(103)]
    public required char ReportingCode { get; init; }

    [Field(104, 107)]
    public required string InitialDepartureMagneticCourse { get; init; }

    [Character(108)]
    public required char AltitudeDescription { get; init; }

    [Field(109, 111)]
    public required string FirstAltitude { get; init; }

    [Field(112, 114)]
    public required string SecondAltitude { get; init; }

    [Field(115, 117)]
    public required string SpeedLimit { get; init; }

    [Field(118, 119)]
    public required string InitialCruiseTable { get; init; }

    [Character(120)]
    public required char SpeedLimitDescription { get; init; }
}
