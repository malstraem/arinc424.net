using System.Reflection;

namespace Arinc424;

public abstract record PropertyDiagnostic : Diagnostic
{
    public required PropertyInfo Property { get; init; }
}
