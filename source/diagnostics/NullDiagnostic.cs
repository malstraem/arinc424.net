namespace Arinc424.Diagnostics;

public class NullDiagnostic(Record424 record, string problem, Range range) : RangeDiagnostic(record, problem, range, DiagnosticType.Nullability);
