namespace Arinc424;

/**<summary>
A basic indicating that <see cref="Record"/> is invalid.
</summary>*/
public abstract record Diagnostic
{
    public required Record424 Record { get; init; }
}
