namespace Arinc424.Procedures.Terms;

/// <summary>
/// <c>Turn Direction (TURN DIR)</c> character.
/// </summary>
/// <remarks>See section 5.20.</remarks>
public enum TurnDirection : byte
{
    Unknown,
    Left,
    Right,
    Either
}
