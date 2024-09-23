using System.Reflection;

namespace Arinc424.Diagnostics;

public abstract class PropertyDiagnostic(DiagnosticType type, Record424 record, PropertyInfo property) : Diagnostic(type, record)
{
    public PropertyInfo Property { get; } = property;
}
