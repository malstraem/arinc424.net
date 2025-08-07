namespace Arinc424.Navigation;

[Port(7, 10), Icao(11, 12), Id(14, 17), Continuous]

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {nameof(Port)} - {{{nameof(Port)}}}")]
public abstract class Landing : Fix
{
    public Ground.Port Port { get; set; }

    [Known(28, 32)]
    public Ground.Touch Touch { get; set; }

    /// <inheritdoc cref="Terms.LandingType"/>
    [Character(18)]
    public Terms.LandingType Type { get; set; }

    /**<summary>
    <para>
      <c>Localizer Bearing (LOC BRG)</c> field for <see cref="InstrumentLanding"/> and <see cref="GlobalLanding"/>.
    </para>
    <para>
      <c>MLS Azimuth Bearing (MLS AZ BRG)</c> field for <see cref="MicrowaveLanding"/>.
    </para>
    </summary>
    <remarks>See section 5.47 and 5.167.</remarks>*/
    [Field(52, 55)]
    public Course Bearing { get; set; }

    /**<summary>
    <c>Component Elevation</c> field.
    </summary>
    <remarks>See section 5.74.</remarks>*/
    [Field(98, 102), Integer]
    [Field<MicrowaveLanding>(104, 108)]
    public int Elevation { get; set; }
}
