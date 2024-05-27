namespace Arinc424.Diagnostics;

public abstract class RangeDiagnostic(Record424 record, string problem, Range range) : Diagnostic(record, problem)
{
    public Range Range { get; } = range;
}
