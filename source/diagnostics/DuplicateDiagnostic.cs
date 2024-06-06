namespace Arinc424.Diagnostics;

public class DuplicateDiagnostic(Record424 record, Type type, string key)
    : Diagnostic(record, $"'{type}' entity with key '{key}' already exist.", DiagnosticType.Duplicate);
