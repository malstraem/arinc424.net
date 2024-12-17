namespace Arinc424.Routing;

/// <summary>
/// <c>Holding Pattern</c> primary record.
/// </summary>
/// <remarks>See section 4.1.5.1.</remarks>
[Section('E', 'P'), Icao(11, 12), Port(7, 10), Continuous(39)]

[DebuggerDisplay($"{nameof(Fix)} - {{{nameof(Fix)}}}")]
public class HoldingPattern : Record424, IIcao, INamed
{
    [Field(35, 36)]
    public string Icao { get; set; }

    /// <summary>
    /// <c>Duplicate Indicator (DUP IND)</c> field.
    /// </summary>
    /// <remarks>See section 5.114.</remarks>
    [Field(28, 29)]
    public string? DuplicateIndicator { get; set; }

    [Type(37, 38)]
    [Identifier(30, 34), Icao(35, 36)]
    public Fix Fix { get; set; }

    /// <summary>
    /// <c>Inbound Holding Course (IB HOLD CRS)</c> field.
    /// </summary>
    /// <remarks>See section 5.62.</remarks>
    [Field(40, 43)]
    public Course In { get; set; }

    /// <inheritdoc cref="Arinc424.Turn"/>
    [Character(44)]
    public Turn Turn { get; set; }

    /// <summary>
    /// <c>Leg Length (LEG LENGTH)</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of mile.</value>
    /// <remarks>See section 5.64.</remarks>
    [Field(45, 47), Float(10)]
    public float LegLength { get; set; }

    /// <summary>
    /// <c>Leg Time (LEG TIME)</c> field.
    /// </summary>
    /// <value>Minutes and tenths of minute.</value>
    /// <remarks>See section 5.65.</remarks>
    [Field(48, 49), Float(10)]
    public float LegTime { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(50, 54)]
    public Altitude Minimum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MaximumAltitude']/*"/>
    [Field(55, 59)]
    public Altitude Maximum { get; set; }

    /// <summary>
    /// <c>Holding Speed (HOLD SPEED)</c> field.
    /// </summary>
    /// <value>Knots.</value>
    /// <remarks>See section 5.175.</remarks>
    [Field(60, 62), Integer]
    public int Speed { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(63, 65), Performance]
    public float Performance { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='ArcRadius']/*"/>
    [Field(66, 71), Float(1000)]
    public float ArcRadius { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='VSF']/*"/>
    [Field(72, 74), Integer]
    public int ScaleFactor { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMinimum']/*"/>
    [Field(75, 77), Integer]
    public int MinLevel { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMaximum']/*"/>
    [Field(78, 80), Integer]
    public int MaxLevel { get; set; }

    /// <inheritdoc cref="LegDirection"/>
    [Character(81)]
    public LegDirection Direction { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Name']/*"/>
    [Field(98, 123)]
    public string? Name { get; set; }
}
