namespace Arinc424.Tables;

using Processing;

/**<summary>
<c>Cruising Table</c> record sequence.
</summary>
<remarks>See section 4.1.16.1.</remarks>*/
[Section('T', 'C'), Id(7, 8)]

[Pipeline<IdentityWrap<CruiseTable, CruiseRow>>]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}")]
public class CruiseTable : Record424<CruiseRow>, IIdentity
{
    /// <summary><c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.</summary>
    /// <remarks>See section 5.134.</remarks>
    [Field(7, 8)]
    public string Identifier { get; set; }
}
