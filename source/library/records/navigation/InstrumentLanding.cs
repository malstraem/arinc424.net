namespace Arinc424.Navigation;

/**<summary>
<c>Airport and Heliport Localizer and Glide Slope</c> primary record.
</summary>
<remarks>See section 4.1.11.1.</remarks>*/
[Section('P', 'I', subIndex: 13)]
public class InstrumentLanding : LandingSystem
{
    /**<summary>
    <c>Localizer Frequency (FREQ)</c> field.
    </summary>
    <value>Kilohertz.</value>
    <remarks>See section 5.45.</remarks>*/
    [Field(23, 27), Decode<LocalizerFrequencyConverter, int>]
    public int Frequency { get; set; }

    [Field(56, 74)]
    public Coordinates GlideSlopeCoordinates { get; set; }

    /**<summary>
    <c>Localizer Position (LOC FR RW END)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.48.</remarks>*/
    [Field(75, 78), Integer]
    public int Position { get; set; }

    [Character(79), Obsolete("todo - combine with position")]
    public char PositionReference { get; set; }

    /**<summary>
    <c>Glide Slope Position (GS FR RW THRES)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.50.</remarks>*/
    [Field(80, 83), Integer]
    public int GlideSlopePosition { get; set; }

    /**<summary>
    <c>Localizer Width (LOC WIDTH)</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.51.</remarks>*/
    [Field(84, 87), Float(100)]
    public float Width { get; set; }

    /**<summary>
    <c>Glide Slope Angle (GS ANGLE)</c> field.
    </summary>
    <value>Degrees.</value>
    <remarks>See section 5.52.</remarks>*/
    [Field(88, 90), Float(100)]
    public float SlopeAngle { get; set; }

    [Field(91, 95), Obsolete("todo")]
    public string Declination { get; set; }

    [Type(109, 110)]
    [Identifier(103, 106), Icao(107, 108)]
    public Fix? SupportingFacility { get; set; }

    /// <include file='Comments.xml' path="doc/member[@name='TCH']/*"/>
    [Field(111, 113), Integer]
    public int ThresholdHeight { get; set; }

    /// <summary>Associated ILS Markers.</summary>
    [Many]
    public List<InstrumentMarker>? Markers { get; set; }
}
