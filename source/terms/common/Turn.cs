namespace Arinc424;

/// <summary>
/// <c>Turn Direction (TURN DIR)</c> and <c>Turn (TURN)</c> character.
/// </summary>
/// <remarks>See section 5.20 and 5.63.</remarks>
public enum Turn : byte
{
    Unknown,
    Left,
    Right,
    Either
}
