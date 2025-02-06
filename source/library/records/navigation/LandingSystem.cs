using Arinc424.Ground;

namespace Arinc424.Navigation;

[Identifier(14, 17), Icao(11, 12), Port(7, 10), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public abstract class LandingSystem : Fix, IIcao
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string Icao { get; set; }

    /// <inheritdoc cref="Terms.LandingType"/>
    [Character(18)]
    public Terms.LandingType Type { get; set; }

    [Identifier(28, 32)]
    public RunwayThreshold Threshold { get; set; }

    /// <summary>
    /// <c>Localizer Bearing (LOC BRG)</c> and <c>MLS Azimuth Bearing (MLS AZ BRG)</c> field.
    /// </summary>
    /// <value>Degrees and tenths of a degree.</value>
    /// <remarks>See section 5.47 and 5.167.</remarks>
    [Field(52, 55)]
    public Course Bearing { get; set; }

    /// <summary>
    /// <c>Component Elevation</c> field.
    /// </summary>
    /// <remarks>See section 5.74.</remarks>
    [Field(98, 102), Integer]
    [Field<MicrowaveLanding>(104, 108)]
    public int Elevation { get; set; }
}
