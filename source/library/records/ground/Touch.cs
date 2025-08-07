namespace Arinc424.Ground;

using Navigation;

[Port(7, 10), Icao(11, 12), Id(14, 18)]
public abstract class Touch : Fix
{
    /// <summary>Associated GLSs.</summary>
    [Many(nameof(Landing.Touch))]
    public GlobalLanding[]? GlobalLandings { get; set; }

    /// <summary>Associated MLSs.</summary>
    [Many(nameof(Landing.Touch))]
    public MicrowaveLanding[]? MicrowaveLandings { get; set; }

    /// <summary>Associated ILSs.</summary>
    [Many(nameof(Landing.Touch))]
    public InstrumentLanding[]? InstrumentLandings { get; set; }

    /// <summary>Associated ILS Markers.</summary>
    [Many(nameof(Landing.Touch))]
    public InstrumentMarker[]? Markers { get; set; }
}
