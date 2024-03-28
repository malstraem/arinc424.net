namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Outbound Magnetic Course (OB MAG CRS)</c> field
/// or <c>Inbound Magnetic Course (IB MAG CRS)</c> field
/// or <c>Magnetic/True Indicator (M/T IND)</c> character.
/// </summary>
/// <remarks>See section 5.26, 5.28, 5.165.</remarks>
public enum CourseType : byte
{
    Unknown,
    Magnetic,
    True,
    Mixed
}
