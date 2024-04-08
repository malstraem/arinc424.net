using Arinc424.Attributes;

namespace Arinc424.Tables;

#pragma warning disable CS8618

/// <summary>
/// <c>Cruising Table</c> record.
/// </summary>
/// <remarks>See section 4.1.16.1.</remarks>
[Record('T', 'C'), Sequenced(9)]
public class CruiseTable : Record424<CruiseTableRow>, IIdentity
{
    /// <summary>
    /// <c>Cruise Table Identifier (CRSE TBL IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.134.</remarks>
    [Field(7, 8), Primary]
    public string Identifier { get; set; }
}
