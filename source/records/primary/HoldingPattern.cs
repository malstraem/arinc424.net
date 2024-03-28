using Arinc.Spec424.Attributes;
using Arinc.Spec424.Converters;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Holding Pattern</c> primary record.
/// </summary>
/// <remarks>See section 4.1.5.1.</remarks>
[Record('E', 'P'), Continuous(39)]
public class HoldingPattern : Record424
{
    /// <summary>
    /// <c>Region Code (REGN CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.41.</remarks>
    [Field(7, 10)]
    public string RegionCode { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14 and Note 1.</remarks>
    [Field(11, 12)]
    public string IcaoCode { get; init; }

    /// <summary>
    /// <c>Duplicate Indicator (DUP IND)</c> field.
    /// </summary>
    /// <remarks>See section 5.114.</remarks>
    [Field(28, 29)]
    public string DuplicateIdentifier { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.13.</remarks>
    [Field(30, 34)]
    public string FixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See section 5.14.</remarks>
    [Field(35, 36)]
    public string FixIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.4.</remarks>
    [Character(37)]
    public char FixSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See section 5.5.</remarks>
    [Character(38)]
    public char FixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Inbound Holding Course (IB HOLD CRS)</c> field.
    /// </summary>
    /// <remarks>See section 5.62.</remarks>
    [Field(40, 43)]
    public string InboundHoldingCourse { get; init; }

    /// <summary>
    /// <c>Turn (TURN)</c> character.
    /// </summary>
    /// <remarks>See section 5.63.</remarks>
    [Character(44)]
    public char TurnDirection { get; init; }

    /// <summary>
    /// <c>Leg Length (LEG LENGTH)</c> field.
    /// </summary>
    /// <remarks>See section 5.64.</remarks>
    [Field(45, 47)]
    public string LegLength { get; init; }

    /// <summary>
    /// <c>Leg Time (LEG TIME)</c> field.
    /// </summary>
    /// <remarks>See section 5.65.</remarks>
    [Field(48, 49)]
    public string LegTime { get; init; }

    /// <summary>
    /// <c>Minimum Altitude</c> field.
    /// </summary>
    /// <remarks>See section 5.30.</remarks>
    [Field(50, 54)]
    public string MinimumAltitude { get; init; }

    /// <summary>
    /// <c>Maximum Altitude (MAX ALT)</c> field.
    /// </summary>
    /// <remarks>See section 5.127.</remarks>
    [Field(55, 59)]
    public string MaximumAltitude { get; init; }

    /// <summary>
    /// <c>Holding Speed (HOLD SPEED)</c> field.
    /// </summary>
    /// <remarks>See section 5.175.</remarks>
    [Field(60, 62)]
    public string HoldingSpeed { get; init; }

    /// <include file='Comments.xml' path="doc/members/member[@name='RNP']/*"/>
    [Field(63, 65), Decode<RnpConverter>]
    public float RequiredNavigationPerformance { get; init; }

    /// <summary>
    /// <c>ARC Radius (ARC RAD)</c> field.
    /// </summary>
    /// <remarks>See section 5.204.</remarks>
    [Field(66, 71)]
    public string ArcRadius { get; init; }

    /// <summary>
    /// <c>Vertical Scale Factor (VSF)</c> field.
    /// </summary>
    /// <remarks>See section 5.293.</remarks>
    [Field(72, 74)]
    public string VerticalScaleFactor { get; init; }

    /// <summary>
    /// <c>RVSM Minimum Leve</c> field.
    /// </summary>
    /// <remarks>See section 5.294.</remarks>
    [Field(75, 77)]
    public string MinimumLevel { get; init; }

    /// <summary>
    /// <c>RVSM Maximum Level</c> field.
    /// </summary>
    /// <remarks>See section 5.295.</remarks>
    [Field(78, 80)]
    public string MaximumLevel { get; init; }

    /// <summary>
    /// <c>Holding Pattern/Race Track Course 
    /// Reversal Leg Inbound/Outbound Indicator</c> character.
    /// </summary>
    /// <remarks>See section 2.298.</remarks>
    [Character(81)]
    public char LegInOutIndicator { get; init; }

    /// <summary>
    /// <c>Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.60.</remarks>
    [Field(98, 123)]
    public string Name { get; init; }
}
