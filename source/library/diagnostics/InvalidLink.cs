using System.Reflection;

namespace Arinc424.Diagnostics;

public class InvalidLink(Record424 record, PropertyInfo property, in KeyInfo info, LinkError error)
    : PropertyDiagnostic(DiagnosticType.InvalidLink, record, property)
{
    public LinkError Error { get; } = error;

    public KeyInfo Info { get; } = info;

    public string? Key { get; internal set; }

    public Type? Type { get; internal set; }
}
