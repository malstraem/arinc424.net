namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>Marker Type (MKR TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.99.</remarks>
[Flags]
public enum MarkerType : byte
{
    Unknown = 0,
    /// <summary>
    /// Inner Marker.
    /// </summary>
    Inner = 1,
    /// <summary>
    /// Middle Marker.
    /// </summary>
    Middle = 1 << 1,
    /// <summary>
    /// Outer Marker.
    /// </summary>
    Outer = 1 << 2,
    /// <summary>
    /// Back Marker.
    /// </summary>
    Back = 1 << 3,
    /// <summary>
    /// Locator at Marker.
    /// </summary>
    Locator = 1 << 4
}
