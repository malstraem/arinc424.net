namespace Arinc424;

/// <summary>
/// <c>Altitude Description (ALT DESC)</c> character.
/// </summary>
/// <remarks>See section 5.29.</remarks>
[Char, Transform<AltitudeDescriptionConverter, AltitudeDescription>]
[Description("Altitude Description (ALT DESC)")]
public enum AltitudeDescription : byte
{
    Unknown,
    /// <summary>
    /// At or above altitude specified in first Altitude field.
    /// </summary>
    [Map('+')] AtAboveFirst,
    /// <summary>
    /// At or below altitude specified in first Altitude field.
    /// </summary>
    [Map('-')] AtBelowFirst,
    /// <summary>
    /// At altitude specified in first Altitude field.
    /// </summary>
    [Map] AtFirst,
    /// <summary>
    /// At or above to at or below altitudes specified in the first and second Altitude fields.
    /// </summary>
    [Map('B')] AtAboveAtBelow,
    /// <summary>
    /// At or above altitude specified in second Altitude field. Condition is which ever is earlier.
    /// </summary>
    [Map('C')] AtAboveSecond,
    /// <summary>
    /// At or above altitude specified in second Altitude field.
    /// Condition is which ever is later, which is operationally equivalent to the condition of not before.
    /// </summary>
    [Map('D')] NotBeforeAtAboveSecond,
    /// <summary>
    /// Glide Slope Altitude (MSL) At Fix, specified in the first Altitude field on the FAF Waypoint
    /// and Glide Slope Intercept Altitude (MSL) in second altitude.
    /// </summary>
    [Map('G')] GlideSecondAtFirst,
    /// <summary>
    /// Glide Slope Altitude (MSL) At Fix, specified in the first Altitude field on the FAF Waypoint
    /// and Glide Slope Intercept Altitude (MSL) in second altitude.
    /// </summary>
    [Map('H')] GlideSecondAtAboveFirst,
    /// <summary>
    /// Glide Slope Intercept Altitude specified in second Altitude field and at altitude specified in first Altitude field.
    /// </summary>
    [Map('I')] GlideInterceptSecondAtFirst,
    /// <summary>
    /// Glide Slope Intercept Altitude specified in second Altitude field and at or above altitude specified in first Altitude field.
    /// </summary>
    [Map('J')] GlideInterceptSecondAtAboveFirst,
    /// <summary>
    /// At or above altitude specified in second Altitude field applicable until established inbound on the racetrack pattern.
    /// Optional at or above altitude specified in first Altitude field applicable at the Fix.
    /// </summary>
    [Map('O')] OptionalAtAbove,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at or above altitude specified in first Altitude field on step-down fix waypoints.
    /// </summary>
    [Map('V')] AtVerticalSecondAtAboveFirst,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at altitude specified in the first Altitude field on step-down fix waypoints.
    /// </summary>
    [Map('X')] AtVerticalSecondAtFirst,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at or below altitude specified in the first Altitude field on step-down fix waypoints.
    /// </summary>
    [Map('Y')] AtVerticalSecondAtBelowFirst
}
