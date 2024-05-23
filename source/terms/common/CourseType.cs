namespace Arinc424;

/// <summary>
/// <para>
///   <c>Outbound Magnetic Course (OB MAG CRS)</c> field.
/// </para>
/// <para>
///   <c>Inbound Magnetic Course (IB MAG CRS)</c> field.
/// </para>
/// <para>
///   <c>Magnetic/True Indicator (M/T IND)</c> character.
/// </para>
/// </summary>
/// <remarks>See section 5.26, 5.28, 5.165.</remarks>
[Char, Flags, Transform<CourseTypeConverter>]
public enum CourseType : byte
{
    Unknown = 0,
    [Map('M')] Magnetic = 1,
    [Map('T')] True = 1 << 1,
    [Map] Mixed = Magnetic | True
}
