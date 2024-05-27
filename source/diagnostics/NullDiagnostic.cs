namespace Arinc424.Diagnostics;

public class NullDiagnostic : RangeDiagnostic
{
    public NullDiagnostic(Record424 record, string problem, Range range) : base(record, problem, range) => diagnosticType = DiagnosticType.Nullability;
}
