namespace Arinc424.Diagnostics;

public abstract record Diagnostic
{
    public required Record424 Record { get; init; }
}
