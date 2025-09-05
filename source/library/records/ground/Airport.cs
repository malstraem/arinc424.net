namespace Arinc424.Ground;

/**<summary>
<c>Airport</c> primary record.
</summary>
<remarks>See section 4.1.7.1.</remarks>*/
[Section('P', 'A', subInd: 13)]
public class Airport : Port
{
    /**<summary>
    <c>Longest Runway (LONGEST RWY)</c> field.
    </summary>
    <value>Feet.</value>
    <remarks>See section 5.54.</remarks>*/
    [Field(28, 30), Integer]
    public int LongestRunwayLength { get; set; }

    /// <inheritdoc cref="Terms.SurfaceType"/>
    [Character(32)]
    public Terms.SurfaceType LongestRunwayType { get; set; }

    /// <summary>Associated gates.</summary>
    [Many(nameof(Gate.Port))]
    public Gate[]? Gates { get; set; }

    /// <summary>Associated runways.</summary>
    [Many(nameof(Threshold.Port))]
    public Threshold[]? Thresholds { get; set; }
}
