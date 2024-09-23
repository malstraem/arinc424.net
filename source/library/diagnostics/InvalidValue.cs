using System.Collections.Immutable;
using System.Reflection;

namespace Arinc424.Diagnostics;

public class InvalidValue(Record424 record, PropertyInfo property, ImmutableArray<char> value, Range range)
    : RangeDiagnostic(DiagnosticType.InvalidValue, record, property, range)
{
    public ImmutableArray<char> Value { get; } = value;
}
