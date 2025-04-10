namespace Arinc424.Navigation.Terms;

/**<summary>
<c>Marker Type (MKR TYPE)</c> field.
</summary>
<remarks>See section 5.99.</remarks>*/
[String, Flags, Decode<MarkerTypeConverter, MarkerType>]
[Description("Marker Type (MKR TYPE)")]
public enum MarkerType : byte
{
    Unknown = 0,
    /**<summary>
    Locator at Marker.
    </summary>*/
    [Map('L')] Locator = 1,
    /**<summary>
    Inner Marker.
    </summary>*/
    [Offset, Map('I')] Inner = 1 << 1,
    /**<summary>
    Middle Marker.
    </summary>*/
    [Map('M')] Middle = 1 << 2,
    /**<summary>
    Outer Marker.
    </summary>*/
    [Map('O')] Outer = 1 << 3,
    /**<summary>
    Back Marker.
    </summary>*/
    [Map('B')] Back = 1 << 4,
}
