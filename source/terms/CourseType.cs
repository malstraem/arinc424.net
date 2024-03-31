namespace Arinc.Spec424.Terms;

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
[Flags]
public enum CourseType : byte
{
    Unknown = 0,
    Magnetic = 1,
    True = 1 << 1,
    Mixed = Magnetic | True
}
