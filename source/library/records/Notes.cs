namespace Arinc424;

/**<summary>
Base continuation record with notes.
</summary>
<remarks>See section 5.91.</remarks>*/
public abstract class BaseContinuation : Record424
{
    [Field(24, 92)]
    [Field<AirwayContinuation>(41, 109)]
    public string? Notes { get; set; }
}

/**<summary>
<c>Enroute Airways</c> continuation record.
</summary>
<remarks>See section 4.1.6.2.</remarks>*/
[Continuation(40)]
public class AirwayContinuation : BaseContinuation;
