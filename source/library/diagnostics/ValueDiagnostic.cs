using System.Reflection;

namespace Arinc424.Diagnostics;

public class ValueDiagnostic(Record424 record, PropertyInfo property, string problem, Range range)
    : RangeDiagnostic(record, problem, range, DiagnosticType.InvalidValue)
{
    public PropertyInfo Property { get; } = property;
}
