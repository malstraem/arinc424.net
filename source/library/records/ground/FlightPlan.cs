namespace Arinc424.Ground;

/// <summary>
/// <c>Flight Planning</c> primary record.
/// </summary>
/// <remarks>See section 4.1.27.1.</remarks>
[Obsolete("todo")]
[Section('P', 'R', subsectionIndex: 13), ContinuousAttribute(70)]
public class FlightPlan : Record424
{
    [Field(7, 10)]
    public string AirportIdentifier { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    [Field(14, 19)]
    public string ProcedureIdentifier { get; set; }

    [Character(20)]
    public char ProcedureType { get; set; }

    [Field(21, 25)]
    public string RunwayTransitionIdentifier { get; set; }

    [Field(26, 30)]
    public string RunwayTransitionFix { get; set; }

    [Field(31, 32)]
    public string RunwayTransitionFixIcaoCode { get; set; }

    [Character(33)]
    public char RunwayTransitionFixSectionCode { get; set; }

    [Character(34)]
    public char FixSubsectionCode { get; set; }

    [Field(35, 37)]
    public string RunwayTransitionAlongTrackDistance { get; set; }

    [Field(38, 42)]
    public string CommonSegmentTransitionFix { get; set; }

    [Field(43, 44)]
    public string CommonSegmentTransitionFixIcaoCode { get; set; }

    [Character(45)]
    public char CommonSegmentTransitionFixSectionCode { get; set; }

    [Character(46)]
    public char CommonSegmentTransitionFixSubsectionCode { get; set; }

    [Field(47, 49)]
    public string CommonSegmentAlongTrackDistance { get; set; }

    [Field(50, 54)]
    public string EnrouteTransitionIdentifier { get; set; }

    [Field(55, 59)]
    public string EnrouteTransitionFix { get; set; }

    [Field(60, 61)]
    public string EnrouteTransitionFixIcaoCode { get; set; }

    [Character(62)]
    public char EnrouteTransitionFixSectionCode { get; set; }

    [Character(63)]
    public char EnrouteTransitionFixSubsectionCode { get; set; }

    [Field(64, 66)]
    public string EnrouteTransitionAlongTrackDistance { get; set; }

    [Field(67, 69)]
    public string SequenceNumber { get; set; }

    [Character(70)]
    public char ContinuationRecordNumber { get; set; }

    [Field(71, 74)]
    public string EnginesNumber { get; set; }

    /// <summary>
    /// <c>Turboprop/Jet Indicator (TURBO)</c> character.
    /// </summary>
    /// <remarks>See section 5.233.</remarks>
    [Character(75)]
    public char EngineTypeRestriction { get; set; }

    [Character(76)]
    public char IsRnav { get; set; }

    [Character(77)]
    public char AtcWeightCategory { get; set; }

    [Field(78, 84)]
    public string AtcIdentifier { get; set; }

    [Character(85)]
    public char TimeCode { get; set; }

    [Field(86, 100)]
    public string ProcedureDescription { get; set; }

    [Field(101, 102)]
    public string LegTypeCode { get; set; }

    [Character(103)]
    public char ReportingCode { get; set; }

    [Field(104, 107)]
    public string InitialDepartureMagneticCourse { get; set; }

    [Character(108)]
    public char AltitudeDescription { get; set; }

    [Field(109, 111)]
    public string FirstAltitude { get; set; }

    [Field(112, 114)]
    public string SecondAltitude { get; set; }

    [Field(115, 117)]
    public string SpeedLimit { get; set; }

    [Field(118, 119)]
    public string InitialCruiseTable { get; set; }

    [Character(120)]
    public char SpeedLimitDescription { get; set; }
}
