using Arinc424.Ports;

namespace Arinc424.Navigation;

[Identifier(14, 17), Icao(11, 12), Port(7, 10), Continuous]
[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Airport)} - {{{nameof(Airport)}}}")]
public abstract class LandingSystem : Geo, IIdentity, IIcao
{
    [Identifier(7, 10)]
    public Airport Airport { get; set; }

    [Field(11, 12)]
    public string IcaoCode { get; set; }

    /// <summary>
    /// <c>Localizer/MLS/GLS Identifier (LOC, MLS, GLS IDENT)</c> field.
    /// </summary>
    /// <remarks>See section 5.44.</remarks>
    [Field(14, 17)]
    public string Identifier { get; set; }

    /// <inheritdoc cref="Terms.LandingSystemType"/>
    [Character(18)]
    public Terms.LandingSystemType Type { get; set; }

    [Identifier(28, 32)]
    public Runway Runway { get; set; }

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
    [Field<MicrowaveLandingSystem>(104, 108)]
    public int Elevation { get; set; }
}
