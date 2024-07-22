namespace Arinc424.Airspace.Terms;

/// <summary>
/// <c>Controlled Airspace Classification (ARSP CLASS)</c> character.
/// </summary>
/// <remarks>See section 5.215.</remarks>
[Char, Transform<AirspaceClassConverter, AirspaceClass>]
[Description("Controlled Airspace Classification (ARSP CLASS)")]
public enum AirspaceClass : byte
{
    Unknown,
    [Map('A')] Alpha,
    [Map('B')] Bravo,
    [Map('C')] Charlie,
    [Map('D')] Delta,
    [Map('E')] Echo,
    [Map('F')] Foxtrot,
    [Map('G')] Golf
}
