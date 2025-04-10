namespace Arinc424;

/**<summary>
/<c>Unit Indicator (UNIT IND)</c> character.
</summary>
<remarks>See section 5.133.</remarks>*/
[Char, Transform<LimitUnitConverter, LimitUnit>]
[Description("Unit Indicator (UNIT IND)")]
public enum LimitUnit : byte
{
    Unknown,
    [Map('M')] Sea,
    [Map('A')] Ground
}
