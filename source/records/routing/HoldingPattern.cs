using System.Diagnostics;

using Arinc424.Attributes;
using Arinc424.Converters;
using Arinc424.Navigation;
using Arinc424.Waypoints;

namespace Arinc424.Routing;

#pragma warning disable CS8618

/// <summary>
/// <c>Holding Pattern</c> primary record.
/// </summary>
/// <remarks>See section 4.1.5.1.</remarks>
[Section('E', 'P'), Continuous(39)]
[DebuggerDisplay($"Fix - {{{nameof(Fix)}}}")]
public class HoldingPattern : Record424, IIcao
{
    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Duplicate Indicator (DUP IND)</c> field.
    /// </summary>
    /// <remarks>See section 5.114.</remarks>
    [Field(28, 29)]
    public string? DuplicateIndicator { get; set; }

    [Type(37, 38)]
    [Foreign<AirportBeacon, AirportTerminalWaypoint>(7, 12), Foreign(30, 36)]
    public Geo Fix { get; set; }

    /// <summary>
    /// <c>Inbound Holding Course (IB HOLD CRS)</c> field.
    /// </summary>
    /// <remarks>See section 5.62.</remarks>
    [Field(40, 43), Decode<CourseConverter>]
    public Course In { get; set; }

    /// <inheritdoc cref="Arinc424.Turn"/>
    [Character(44), Transform<TurnConverter>]
    public Turn Turn { get; set; }

    /// <summary>
    /// <c>Leg Length (LEG LENGTH)</c> field.
    /// </summary>
    /// <value>Nautical miles and tenths of mile.</value>
    /// <remarks>See section 5.64.</remarks>
    [Field(45, 47), Decode<TenthsConverter>]
    public float LegLength { get; set; }

    /// <summary>
    /// <c>Leg Time (LEG TIME)</c> field.
    /// </summary>
    /// <value>Minutes and tenths of minute.</value>
    /// <remarks>See section 5.65.</remarks>
    [Field(48, 49), Decode<TenthsConverter>]
    public float LegTime { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='Altitude']/*"/>
    [Field(50, 54), Decode<AltitudeConverter>]
    public Altitude Minimum { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='MaximumAltitude']/*"/>
    [Field(55, 59), Decode<AltitudeConverter>]
    public Altitude Maximum { get; set; }

    /// <summary>
    /// <c>Holding Speed (HOLD SPEED)</c> field.
    /// </summary>
    /// <value>Knots.</value>
    /// <remarks>See section 5.175.</remarks>
    [Field(60, 62), Decode<IntConverter>]
    public int Speed { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RNP']/*"/>
    [Field(63, 65), Decode<NavigationPerformanceConverter>]
    public float NavigationPerformance { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='ArcRadius']/*"/>
    [Field(66, 71), Decode<ThousandsConverter>]
    public float ArcRadius { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='VSF']/*"/>
    [Field(72, 74), Decode<IntConverter>]
    public int ScaleFactor { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMinimum']/*"/>
    [Field(75, 77), Decode<IntConverter>]
    public int MinLevel { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='RvsmMaximum']/*"/>
    [Field(78, 80), Decode<IntConverter>]
    public int MaxLevel { get; set; }

    /// <inheritdoc cref="LegDirection"/>
    [Character(81), Transform<LegDirectionConverter>]
    public LegDirection Direction { get; set; }

    /// <summary>
    /// <c>Name (NAME)</c> field.
    /// </summary>
    /// <remarks>See section 5.60.</remarks>
    [Field(98, 123)]
    public string? Name { get; set; }
}
