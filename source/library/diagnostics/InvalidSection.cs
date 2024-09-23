using System.Reflection;

namespace Arinc424.Diagnostics;

public class InvalidSection(Record424 record, PropertyInfo property, int section, int subsection)
    : PropertyDiagnostic(DiagnosticType.InvalidSection, record, property)
{
    public int SectionIndex { get; } = section;

    public int SubsectionIndex { get; } = subsection;
}
