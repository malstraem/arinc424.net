namespace Arinc424.Airspace.Terms;

/**<summary>
<c>Restrictive Airspace Type (REST TYPE)</c> character.
</summary>
<remarks>See section 5.128.</remarks>*/
[Char, Transform<RestrictiveTypeConverter, RestrictiveType>]
[Description("Restrictive Airspace Type (REST TYPE)")]
public enum RestrictiveType : byte
{
    Unknown,
    [Map('A')] Alert,
    [Map('C')] Caution,
    [Map('D')] Danger,
    [Map('L')] LongTerm,
    [Map('M')] MilitaryOperations,
    [Map('N')] NationalSecurity,
    [Map('P')] Prohibited,
    [Map('R')] Restricted,
    [Map('T')] Training,
    [Map('W')] Warning,
    [Map('U')] Unspecified
}
