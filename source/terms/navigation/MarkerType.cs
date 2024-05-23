namespace Arinc424.Navigation.Terms;

/// <summary>
/// <c>Marker Type (MKR TYPE)</c> field.
/// </summary>
/// <remarks>See section 5.99.</remarks>
[String, Flags, Decode<MarkerTypeConverter>]
public enum MarkerType : byte
{
    Unknown = 0,
    [Map('L')]
    Locator = 1,

    [Offset]
    [Map('I')] Inner = 1 << 1,
    [Map('M')] Middle = 1 << 2,
    [Map('O')] Outer = 1 << 3,
    [Map('B')] Back = 1 << 4,
}
