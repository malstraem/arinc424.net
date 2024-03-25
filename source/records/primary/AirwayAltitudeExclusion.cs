using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

/// <summary>
/// <c>Enroute Airways Restriction Altitude Exclusion</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.21.1.</remarks>
[Record('E', 'U'), Continuous(18)]
public class AirwayAltitudeExclusion : Record424
{
    /// <summary>
    /// <c>Route Identifier (ROUTE IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.8.</remarks>
    [Field(7, 11)]
    public required string RouteIdentifier { get; init; }

    /// <summary>
    /// <c>Restriction Identifier (REST IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.154.</remarks>
    [Field(13, 15)]
    public required string Identifier { get; init; }

    /// <summary>
    /// <c>Restriction Record Type (REST TYPE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.201.</remarks>
    [Field(16, 17)]
    public required string Type { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13.</remarks>
    [Field(19, 23)]
    public required string StartFixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(24, 25)]
    public required string StartFixIcaoCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(26)]
    public required char StartFixSectionCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(27)]
    public required char StartFixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Fix Identifier (FIX IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.13.</remarks>
    [Field(28, 32)]
    public required string EndFixIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(33, 34)]
    public required string EndFixIcaoCode { get; init; }

    /// <summary>
    /// <c>Subsection Code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(35)]
    public required char EndFixSectionCode { get; init; }

    /// <summary>
    /// <c>Section Code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(36)]
    public required char EndFixSubsectionCode { get; init; }

    /// <summary>
    /// <c>Airway Restriction Start/End Date (START/END DATE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.157.</remarks>
    [Field(38, 44)]
    public required string? StartDate { get; init; }

    /// <summary>
    /// <c>Airway Restriction Start/End Date (START/END DATE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.157.</remarks>
    [Field(45, 51)]
    public required string? EndDate { get; init; }

    /// <summary>
    /// <c>Time Code (TIME CD)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.131.</remarks>
    [Character(52)]
    public required char TimeCode { get; init; }

    /// <summary>
    /// <c>Time Indicator (TIME IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.138.</remarks>
    [Character(53)]
    public required char TimeIndicator { get; init; }

    /// <summary>
    /// <c>Time of Operation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.195.</remarks>
    [Field(54, 63)]
    public required string TimeOfOperation1 { get; init; }

    /// <summary>
    /// <c>Time of Operation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.195.</remarks>
    [Field(64, 73)]
    public required string TimeOfOperation2 { get; init; }

    /// <summary>
    /// <c>Time of Operation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.195.</remarks>
    [Field(74, 83)]
    public required string TimeOfOperation3 { get; init; }

    /// <summary>
    /// <c>Time of Operation</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.195.</remarks>
    [Field(84, 93)]
    public required string TimeOfOperation4 { get; init; }

    /// <summary>
    /// <c>Exclusion Indicator (EXC IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.202.</remarks>
    [Character(94)]
    public required char ExclusionIndicator { get; init; }

    /// <summary>
    /// <c>Units of Altitude (UNIT IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.160.</remarks>
    [Character(95)]
    public required char AltitudeUnits { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(96, 98)]
    public required string? RestrictionAltitude1 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(99)]
    public required char BlockIndicator1 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(100, 102)]
    public required string RestrictionAltitude2 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(103)]
    public required char BlockIndicator2 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(104, 106)]
    public required string RestrictionAltitude3 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(107)]
    public required char BlockIndicator3 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(108, 110)]
    public required string RestrictionAltitude4 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(111)]
    public required char BlockIndicator4 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(112, 114)]
    public required string? RestrictionAltitude5 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(115)]
    public required char? BlockIndicator5 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(116, 118)]
    public required string? RestrictionAltitude6 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(119)]
    public required char? BlockIndicator6 { get; init; }

    /// <summary>
    /// <c>Restriction Altitude (RSTR ALT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.161.</remarks>
    [Field(120, 122)]
    public required string? RestrictionAltitude7 { get; init; }

    /// <summary>
    /// <c>Block Indicator (BLOCK IND)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.203.</remarks>
    [Character(123)]
    public required char? BlockIndicator7 { get; init; }
}
