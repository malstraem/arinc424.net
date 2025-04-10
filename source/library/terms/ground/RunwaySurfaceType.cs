namespace Arinc424.Ground.Terms;

/**<summary>
<c>Surface Code (SC)</c> character.
</summary>
<remarks>See section 5.249.</remarks>*/
[Char, Transform<SurfaceTypeConverter, SurfaceType>]
[Description("Surface Code (SC)")]
public enum SurfaceType : byte
{
    Unknown,
    /**<summary>
    Surface material not provided in source.
    </summary>*/
    [Map('U')] Unspecified,
    /**<summary>
    Hard runway, for example, asphalt or concrete.
    </summary>*/
    [Map('H')] Hard,
    /**<summary>
    Soft runway, for example, gravel, grass or soil.
    </summary>*/
    [Map('S')] Soft,
    /**<summary>
    Water runway.
    </summary>*/
    [Map('W')] Water
}
