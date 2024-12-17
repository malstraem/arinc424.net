namespace Arinc424;

/// <summary>
/// <c>Magnetic/True Indicator (M/T IND)</c> character.
/// </summary>
/// <remarks>See section 5.165.</remarks>
[Flags, Transform<CourseTypeConverter, CourseType>]
public enum CourseType : byte
{
    Unknown = 0,
    /// <summary>
    /// Value are provided in magnetic.
    /// </summary>
    [Map('M')] Magnetic = 1,
    /// <summary>
    /// Value are provided in true.
    /// </summary>
    [Map('T')] True = 1 << 1
}
