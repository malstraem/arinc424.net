namespace Arinc424;

/// <summary>
/// <c>Level (LEVEL)</c> character.
/// </summary>
/// <remarks>See section 5.19.</remarks>
[Char, Flags, Description("Level (LEVEL)")]
public enum LevelType : byte
{
    Unknown = 0,
    [Map('L')] Low = 1,
    [Map('H')] High = 1 << 1,
    [Map('B')] All = Low | High
}
