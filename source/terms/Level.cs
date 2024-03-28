namespace Arinc.Spec424.Terms;

/// <summary>
/// <c>Level (LEVEL)</c> character.
/// </summary>
/// <remarks>See section 5.19</remarks>
[Flags]
public enum Level : byte
{
    Unknown = 0,
    Low = 1,
    High = 1 << 1,
    All = Low | High
}
