namespace Arinc424;

/// <summary>
/// <c>Altitude Description (ALT DESC)</c> character.
/// </summary>
/// <remarks>See section 5.29.</remarks>
public enum AltitudeDescription : byte
{
    Unknown,
    /// <summary>
    /// At or above altitude specified in first Altitude field.
    /// </summary>
    AtAboveFirst,
    /// <summary>
    /// At or below altitude specified in first Altitude field.
    /// </summary>
    AtBelowFirst,
    /// <summary>
    /// At altitude specified in first Altitude field.
    /// </summary>
    AtFirst,
    /// <summary>
    /// At or above to at or below altitudes specified in the first and second Altitude fields.
    /// </summary>
    AtAboveAtBelow,
    /// <summary>
    /// At or above altitude specified in second Altitude field. Condition is which ever is earlier.
    /// </summary>
    AtAboveSecond,
    /// <summary>
    /// At or above altitude specified in second Altitude field.
    /// Condition is which ever is later, which is operationally equivalent to the condition of not before.
    /// </summary>
    AtAboveSecondNotBefore,
    /// <summary>
    /// Glide Slope Altitude (MSL) At Fix, specified in the first Altitude field on the FAF Waypoint
    /// and Glide Slope Intercept Altitude (MSL) in second altitude of FAF Waypoint in Precision Approach Coding with electronic Glide Slope.
    /// </summary>
    GlideSlope,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at or above altitude specified in first Altitude field on step-down fix waypoints.
    /// </summary>
    AtVerticalSecondAtAboveFirst,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at altitude specified in the first Altitude field on step-down fix waypoints.
    /// </summary>
    AtVerticalSecondAtFirst,
    /// <summary>
    /// At altitude on the coded vertical angle in the second Altitude field
    /// and at or below altitude specified in the first Altitude field on step-down fix waypoints.
    /// </summary>
    AtVerticalSecondAtBelowFirst
}
