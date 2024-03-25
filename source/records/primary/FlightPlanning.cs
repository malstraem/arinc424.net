using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Flight Planning</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.27.1.</remarks>
[Record('P', 'R', subsectionIndex: 13), Continious(70)]
public class FlightPlanning : Record424
{
    [Field(7, 10)]
    public string AirportIdentifier { get; init; }

    [Field(11, 12)]
    public string IcaoCode { get; init; }

    [Field(14, 19)]
    public string ProcedureIdentifier { get; init; }

    [Character(20)]
    public char ProcedureType { get; init; }

    [Field(21, 25)]
    public string RunwayTransitionIdentifier { get; init; }

    [Field(26, 30)]
    public string RunwayTransitionFix { get; init; }

    [Field(31, 32)]
    public string RunwayTransitionFixIcaoCode { get; init; }

    [Character(33)]
    public char RunwayTransitionFixSectionCode { get; init; }

    [Character(34)]
    public char FixSubsectionCode { get; init; }

    [Field(35, 37)]
    public string RunwayTransitionAlongTrackDistance { get; init; }

    [Field(38, 42)]
    public string CommonSegmentTransitionFix { get; init; }

    [Field(43, 44)]
    public string CommonSegmentTransitionFixIcaoCode { get; init; }

    [Character(45)]
    public char CommonSegmentTransitionFixSectionCode { get; init; }

    [Character(46)]
    public char CommonSegmentTransitionFixSubsectionCode { get; init; }

    [Field(47, 49)]
    public string CommonSegmentAlongTrackDistance { get; init; }

    [Field(50, 54)]
    public string EnrouteTransitionIdentifier { get; init; }

    [Field(55, 59)]
    public string EnrouteTransitionFix { get; init; }

    [Field(60, 61)]
    public string EnrouteTransitionFixIcaoCode { get; init; }

    [Character(62)]
    public char EnrouteTransitionFixSectionCode { get; init; }

    [Character(63)]
    public char EnrouteTransitionFixSubsectionCode { get; init; }

    [Field(64, 66)]
    public string EnrouteTransitionAlongTrackDistance { get; init; }

    [Field(67, 69)]
    public string SequenceNumber { get; init; }

    [Character(70)]
    public char ContinuationRecordNumber { get; init; }

    [Field(71, 74)]
    public string EnginesNumber { get; init; }

    /// <summary>
    /// <c>Turboprop/Jet Indicator (TURBO)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.233.</remarks>
    [Character(75)]
    public char EngineTypeRestriction { get; init; }

    [Character(76)]
    public char IsRnav { get; init; }

    [Character(77)]
    public char AtcWeightCategory { get; init; }

    [Field(78, 84)]
    public string AtcIdentifier { get; init; }

    [Character(85)]
    public char TimeCode { get; init; }

    [Field(86, 100)]
    public string ProcedureDescription { get; init; }

    [Field(101, 102)]
    public string LegTypeCode { get; init; }

    [Character(103)]
    public char ReportingCode { get; init; }

    [Field(104, 107)]
    public string InitialDepartureMagneticCourse { get; init; }

    [Character(108)]
    public char AltitudeDescription { get; init; }

    [Field(109, 111)]
    public string FirstAltitude { get; init; }

    [Field(112, 114)]
    public string SecondAltitude { get; init; }

    [Field(115, 117)]
    public string SpeedLimit { get; init; }

    [Field(118, 119)]
    public string InitialCruiseTable { get; init; }

    [Character(120)]
    public char SpeedLimitDescription { get; init; }
}
