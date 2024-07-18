using Arinc424.Navigation;

namespace Arinc424.Ports;

using Terms;

/// <summary>
/// <c>Airport</c> primary record.
/// </summary>
/// <remarks>See section 4.1.7.1.</remarks>
[Section('P', 'A', subsectionIndex: 13)]
public class Airport : Port
{
    /// <summary>
    /// <c>Longest Runway (LONGEST RWY)</c> field.
    /// </summary>
    /// <value>Hundreds of feet.</value>
    /// <remarks>See section 5.54.</remarks>
    [Field(28, 30), Integer]
    public int LongestRunwayLength { get; set; }

    /// <inheritdoc cref="RunwaySurfaceType"/>
    [Character(32)]
    public RunwaySurfaceType LongestRunwayType { get; set; }

    /// <summary>
    /// Associated gates.
    /// </summary>
    [Many]
    public List<Gate>? Gates { get; set; }

    /// <summary>
    /// Associated runways.
    /// </summary>
    [Many]
    public List<Runway>? Runways { get; set; }

    /// <summary>
    /// Associated Localizer Markers.
    /// </summary>
    [Many]
    public List<InstrumentMarker>? Markers { get; set; }

    /// <summary>
    /// Associated NDBs.
    /// </summary>
    [Many]
    public List<TerminalBeacon>? Beacons { get; set; }

    /// <summary>
    /// Associated MLS's.
    /// </summary>
    [Many]
    public List<MicrowaveLanding>? MicrowaveLandings { get; set; }

    /// <summary>
    /// Associated ILS's.
    /// </summary>
    [Many]
    public List<InstrumentLanding>? InstrumentLandings { get; set; }

    /// <summary>
    /// Associated VHF Navaids.
    /// </summary>
    [Many]
    public List<Omnidirectional>? Omnidirectionals { get; set; }
}
