namespace Arinc424;

public abstract record Diagnostic
{
    public required Record424 Record { get; init; }
}
