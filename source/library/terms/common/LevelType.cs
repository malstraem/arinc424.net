namespace Arinc424;

/**<summary>
<c>Level (LEVEL)</c> character.
</summary>
<remarks>See section 5.19.</remarks>*/
[Char, Flags, Transform<LevelTypeConverter, LevelType>]
[Description("Level (LEVEL)")]
public enum LevelType : byte
{
    Unknown = 0,
    /**<summary>
    Low Level Airways/Altitudes.
    </summary>*/
    [Map('L')] Low = 1,
    /**<summary>
    High Level Airways/Altitudes.
    </summary>*/
    [Map('H')] High = 1 << 1,
    /**<summary>
    All Altitudes.
    </summary>*/
    [Map('B')] All = Low | High
}
