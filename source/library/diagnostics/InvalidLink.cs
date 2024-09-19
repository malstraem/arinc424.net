using System.Reflection;

using Arinc424.Linking;

namespace Arinc424.Diagnostics;

public class InvalidLink(Record424 record, PropertyInfo property, KeyInfo ranges, LinkError error)
    : PropertyDiagnostic(DiagnosticType.InvalidLink, record, property)
{
    public LinkError Error { get; } = error;

    public KeyInfo Ranges { get; } = ranges;

    public string? Key { get; internal set; }

    public Type? WrongType { get; internal set; }
}
