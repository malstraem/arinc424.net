using System.Reflection;

namespace Arinc424.Diagnostics;

public abstract record PropertyDiagnostic : Diagnostic
{
    public required PropertyInfo Property { get; init; }
}
