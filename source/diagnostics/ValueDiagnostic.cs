namespace Arinc424.Diagnostics;

public class ValueDiagnostic(Record424 record, string problem, Range range) : RangeDiagnostic(record, problem, range, DiagnosticType.InvalidValue);
