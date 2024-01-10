using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Holding Pattern</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.5.1.</remarks>
[Record('E', 'P'), Continuation(39)]
public class HoldingPattern : Record424
{
    /// <summary>
    /// <c>Region Code (REGN CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.41.</remarks>
    [Field(7, 10)]
    public required string RegionCode { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14 and Note 1.</remarks>
    [Field(11, 12)]
    public required string IcaoCode { get; init; }

    /// <summary>
    /// <c>Duplicate Indicator (DUP IND)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.114.</remarks>
    [Field(28, 29)]
    public required string DuplicateIdentifier { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13.</remarks>
    [Field(30, 34)]
    public required string FixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(35, 36)]
    public required string FixIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(37)]
    public required char FixSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(38)]
    public required char FixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Inbound Holding Course (IB HOLD CRS)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.62.</remarks>
    [Field(40, 43)]
    public required string InboundHoldingCourse { get; init; }

    /// <summary>
    /// <c>Turn (TURN)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.63.</remarks>
    [Character(44)]
    public required char TurnDirection { get; init; }

    /// <summary>
    /// <c>Leg Length (LEG LENGTH)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.64.</remarks>
    [Field(45, 47)]
    public required string LegLength { get; init; }

    /// <summary>
    /// <c>Leg Time (LEG TIME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.65.</remarks>
    [Field(48, 49)]
    public required string LegTime { get; init; }

    /// <summary>
    /// <c>Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.30.</remarks>
    [Field(50, 54)]
    public required string MinimumAltitude { get; init; }

    /// <summary>
    /// <c>Maximum Altitude (MAX ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.127.</remarks>
    [Field(55, 59)]
    public required string MaximumAltitude { get; init; }

    /// <summary>
    /// <c>Holding Speed (HOLD SPEED)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.175.</remarks>
    [Field(60, 62)]
    public required string HoldingSpeed { get; init; }

    /// <summary>
    /// <c>Required Navigation Performance (RNP)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.211.</remarks>
    [Field(63, 65)]
    public required string RequiredNavigationPerformance { get; init; }

    /// <summary>
    /// <c>ARC Radius (ARC RAD)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.204.</remarks>
    [Field(66, 71)]
    public required string ArcRadius { get; init; }

    /// <summary>
    /// <c>Vertical Scale Factor (VSF)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.293.</remarks>
    [Field(72, 74)]
    public required string VerticalScaleFactor { get; init; }

    /// <summary>
    /// <c>RVSM Minimum Leve</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.294.</remarks>
    [Field(75, 77)]
    public required string MinimumLevel { get; init; }

    /// <summary>
    /// <c>RVSM Maximum Level</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.295.</remarks>
    [Field(78, 80)]
    public required string MaximumLevel { get; init; }

    /// <summary>
    /// <c>Holding Pattern/Race Track Course 
    /// Reversal Leg Inbound/Outbound Indicator</c> character.
    /// </summary>
    /// <remarks>See paragraph 2.298.</remarks>
    [Character(81)]
    public required char LegInOutIndicator { get; init; }

    /// <summary>
    /// <c>Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.60.</remarks>
    [Field(98, 123)]
    public required string Name { get; init; }
}
