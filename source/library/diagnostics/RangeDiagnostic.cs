using System.Reflection;

namespace Arinc424.Diagnostics;

public abstract class RangeDiagnostic(DiagnosticType type, Record424 record, PropertyInfo property, Range range)
    : PropertyDiagnostic(type, record, property)
{
    public Range Range { get; } = range;
}
