namespace Arinc424;

/// <summary>
/// Boolean type according to the specification.
/// </summary>
[Char, Transform<BoolConverter, Bool>]
public enum Bool : byte
{
    Unknown,
    [Map] Unspecified,
    [Map('Y')] Yes,
    [Map('N')] No
}
