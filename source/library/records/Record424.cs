namespace Arinc424;

/// <summary>
/// Base <c>ARINC-424</c> record with area/customer code, file record number and cycle date fields.
/// </summary>
public abstract class Record424
{
    /// <summary>
    /// The source string from which the record was created.
    /// </summary>
    public string? Source { get; set; }

    /// <summary>
    /// <c>Customer/Area Code (CUST/AREA)</c> field.
    /// </summary>
    /// <remarks>See section 5.3.</remarks>
    [Field(2, 4), Validation("\\w{1,3}")]
    public string? Code { get; set; }

    /// <summary>
    /// <c>File Record Number (FRN)</c> field.
    /// </summary>
    /// <remarks>See section 5.31.</remarks>
    [Field(124, 128), Integer]
    public int Number { get; set; }
}
