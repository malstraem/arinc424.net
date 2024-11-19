namespace Arinc424.Diagnostics;

[Obsolete("todo")]
public class Duplicate(Record424 record, Type type, string key) : Diagnostic(DiagnosticType.Duplicate, record);
