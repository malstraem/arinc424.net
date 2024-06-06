namespace Arinc424;

/// <summary>
/// <c>Holding Pattern/Race Track Course Reversal Leg Inbound/Outbound Indicator</c> character.
/// </summary>
/// <remarks>See section 5.298.</remarks>
[Char, Transform<LegDirectionConverter, LegDirection>]
[Description("Holding Pattern/Race Track Course Reversal Leg Inbound/Outbound Indicator")]
public enum LegDirection : byte
{
    Unknown,
    [Map('I')] Inbound,
    [Map('O')] Outbound
}
