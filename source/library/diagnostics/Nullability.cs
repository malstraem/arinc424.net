using System.Reflection;

namespace Arinc424.Diagnostics;

public class Nullability(Record424 record, PropertyInfo property, Range range) : RangeDiagnostic(DiagnosticType.Null, record, property, range);
