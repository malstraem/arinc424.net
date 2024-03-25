using Arinc.Spec424.Attributes;

namespace Arinc.Spec424.Records;

#pragma warning disable CS8618

/// <summary>
/// <c>Airport and Heliport MLS (Azimuth, Elevation and Back Azimuth)</c> primary record.
/// </summary>
/// <remarks>See paragraph 4.1.22.1.</remarks>
[Record('P', 'L', subsectionIndex: 13), Continious]
public class MicrowaveLandingSystem : Record424, IIdentity
{
    [Foreign(7, 12)]
    public Airport Airport { get; init; }

    /// <summary>
    /// <c>MLS Identifier</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.44.</remarks>
    [Field(14, 17)]
    public string Identifier { get; init; }

    /// <summary>
    /// <c>MLS Category (CAT)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.80.</remarks>
    [Character(18)]
    public char Category { get; init; }

    /// <summary>
    /// <c>Channel</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.166.</remarks>
    [Field(23, 25)]
    public string Channel { get; init; }

    /// <summary>
    /// <c>Runway Identifier (RUNWAY ID)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.46.</remarks>
    [Field(28, 32)]
    public string RunwayIdentifier { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(33, 41)]
    public string AzimuthLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(42, 51)]
    public string AzimuthLongitude { get; init; }

    /// <summary>
    /// <c>MLS Azimuth Bearing (MLS AZ BRG)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.167.</remarks>
    [Field(52, 55)]
    public string AzimuthBearing { get; init; }

    /// <summary>
    /// <c>Latitude (LATITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.36.</remarks>
    [Field(56, 64)]
    public string ElevationLatitude { get; init; }

    /// <summary>
    /// <c>Longitude (LONGITUDE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.37.</remarks>
    [Field(65, 74)]
    public string ElevationLongitude { get; init; }

    /// <summary>
    /// <c>Azimuth/Back Azimuth Position (AZ/BAZ FR RW END)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.48.</remarks>
    [Field(75, 78)]
    public string AzimuthPosition { get; init; }

    /// <summary>
    /// <c>Azimuth Position Reference (@, +, -)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.49.</remarks>
    [Character(79)]
    public char AzimuthPositionReference { get; init; }

    /// <summary>
    /// <c>Elevation Position (EL FR RW THRES)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.50.</remarks>
    [Field(80, 83)]
    public string ElevationPosition { get; init; }

    /// <summary>
    /// <c>Azimuth Proportional Angle Right(AZ PRO RIGHT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.168.</remarks>
    [Field(84, 86)]
    public string AzimuthProportionalAngleRight { get; init; }

    /// <summary>
    /// <c>Azimuth Proportional Angle Right(AZ PRO LEFT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.168.</remarks>
    [Field(87, 89)]
    public string AzimuthProportionalAngleLeft { get; init; }

    /// <summary>
    /// <c>Azimuth Coverage Sector Right (AZ COV RIGHT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.172.</remarks>
    [Field(90, 92)]
    public string AzimuthCoverageRight { get; init; }

    /// <summary>
    /// <c>Azimuth Coverage Sector Left(AZ COV LEFT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.172.</remarks>
    [Field(93, 95)]
    public string AzimuthCoverageSectorLeft { get; init; }

    /// <summary>
    /// <c>Elevation Angle Span (EL ANGLE SPAN)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.169.</remarks>
    [Field(96, 98)]
    public string ElevationAngleSpan { get; init; }

    /// <summary>
    /// <c>Magnetic Variation (MAG VAR, D MAG VAR)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.39.</remarks>
    [Field(99, 103)]
    public string MagneticVariation { get; init; }

    /// <summary>
    /// <c>Component Elevation (EL ELEV)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.74.</remarks>
    [Field(104, 108)]
    public string ComponentElevation { get; init; }

    /// <summary>
    /// <c>Nominal Elevation Angle (NOM ELEV ANGLE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.173.</remarks>
    [Field(109, 112)]
    public string NominalElevationAngle { get; init; }

    /// <summary>
    /// <c>Glide Slope Angle (GS ANGLE) Minimum Elevation Angle (MIN ELEV ANGLE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.52.</remarks>
    [Field(113, 115)]
    public string? MinimumGlidePathAngle { get; init; }

    /// <summary>
    /// <c>NDB Identifier (NDB IDENT)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.33.</remarks>
    [Field(116, 119)]
    public string SupportingFacilityIdentifier { get; init; }

    /// <summary>
    /// <c>ICAO Code (ICAO CODE)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.14.</remarks>
    [Field(120, 121)]
    public string SupportingFacilityIcaoCode { get; init; }

    /// <summary>
    /// <c>Section code (SEC CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.4.</remarks>
    [Character(122)]
    public char SupportingFacilitySectionCode { get; init; }

    /// <summary>
    /// <c>Subsection code (SUB CODE)</c> character.
    /// </summary>
    /// <remarks>See paragraph 5.5.</remarks>
    [Character(123)]
    public char SupportingFacilitySubsectionCode { get; init; }
}
