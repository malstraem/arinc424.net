namespace Arinc424;

/**<summary>
Base continuation record with notes.
</summary>
<remarks>See section 5.91.</remarks>*/
[Continuation]
public class Notes : Record424
{
    [Field(24, 92)]
    public string Note { get; set; }
}

[Continuation(40)]
public class AirwayNotes : Record424
{
    [Field(41, 109)]
    public string Note { get; set; }
}
