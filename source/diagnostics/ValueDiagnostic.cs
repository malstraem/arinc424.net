namespace Arinc424.Diagnostics;

public class ValueDiagnostic : RangeDiagnostic
{
    public ValueDiagnostic(Record424 record, string problem, Range range) : base(record, problem, range) => diagnosticType = DiagnosticType.InvalidValue;
}
