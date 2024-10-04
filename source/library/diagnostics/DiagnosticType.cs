namespace Arinc424.Diagnostics;

[Flags]
public enum DiagnosticType : byte
{
    Null = 0,
    Duplicate = 1,
    InvalidLink = 1 << 1,
    InvalidType = 1 << 2,
    InvalidValue = 1 << 3,
    InvalidSection = 1 << 4,
}
