using Arinc.Spec424.Attributes;

namespace Arinc.Spec424;

#pragma warning disable CS8618

/// <summary>
/// Base ARINC-424 record having area/customer code, file record number and cycle date fields.
/// </summary>
public abstract class Record424
{
    /// <summary>
    /// <c>Customer/Area Code (CUST/AREA)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.3.</remarks>
    [Field(2, 4), Validation("\\w{1,3}")]
    public string AreaCode { get; init; }

    /*/// <summary>
    /// <c>File Record Number (FRN)</c> field.
    /// </summary>
    /// <remarks>See paragraph 5.31.</remarks>
    [Field(124, 128), Decode<NumericConverter>]
    public int RecordNumber { get; init; }*/
}
