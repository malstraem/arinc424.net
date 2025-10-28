namespace Arinc424.Airspace.Terms;

using T = RegionType;

/**<summary>
<c>FIR/UIR Indicator (IND)</c> character.
</summary>
<remarks>See section 5.117.</remarks>*/
[Char, Flags, Transform<RegionTypeConverter, T>]
[Description("FIR/UIR Indicator (IND)")]
public enum RegionType : byte
{
    Unknown = 0,
    /**<summary>
    FIR.
    </summary>*/
    [Map('F')]
    [Sum<T>(Upper, 'B')]
    Flight = 1,
    /**<summary>
    UIR.
    </summary>*/
    [Map('U')]
    Upper = 1 << 1
}
