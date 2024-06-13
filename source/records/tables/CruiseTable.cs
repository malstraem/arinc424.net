namespace Arinc424.Tables;

/// <summary>
/// <c>Cruising Table</c> record.
/// </summary>
/// <remarks>See section 4.1.16.1.</remarks>
[Section('T', 'C'), Sequenced(9)]
[DebuggerDisplay($"{{{nameof(Identifier)}}}")]
public class CruiseTable : Record424<CruiseRow>, IIdentity
{
    /// <summary>
    /// <c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.134.</remarks>
    [Field(7, 8), Primary]
    public string Identifier { get; set; }
}
