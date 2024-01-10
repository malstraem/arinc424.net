namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Magnetic/True Indicator (M/T IND)</c> character.
/// </summary>
/// <remarks>See paragraph 5.165.</remarks>
public enum CourseType : byte
{
    Unknown,
    Magnetic,
    True,
    Mixed
}
