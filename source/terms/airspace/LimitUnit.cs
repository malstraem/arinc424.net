namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>Unit Indicator (UNIT IND)</c> character.
/// </summary>
/// <remarks>See section 5.133.</remarks>
[Char, Description("Unit Indicator (UNIT IND)")]
public enum LimitUnit : byte
{
    Unknown,
    [Map('M')] Sea,
    [Map('G')] Ground
}
