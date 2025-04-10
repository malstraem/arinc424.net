namespace Arinc424.Airspace.Terms;

/**<summary>
<c>FIR/UIR Indicator (IND)</c> character.
</summary>
<remarks>See section 5.117.</remarks>*/
[Flags, Transform<RegionTypeConverter, RegionType>]
[Description("FIR/UIR Indicator (IND)")]
public enum RegionType : byte
{
    Unknown = 0,
    /**<summary>
    FIR.
    </summary>*/
    Flight = 1,
    /**<summary>
    UIR.
    </summary>*/
    Upper = 1 << 1
}
