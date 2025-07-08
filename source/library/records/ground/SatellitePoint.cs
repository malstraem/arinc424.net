namespace Arinc424.Ground;

/**<summary>
<c>SBAS Path Point</c> primary record.
</summary>
<remarks>See section 4.1.28.1 and 4.2.8.1.</remarks>*/
[Section('P', 'P', subIndex: 13), Section('H', 'P', subIndex: 13)]
public class SatellitePoint : PathPoint
{
    /// <inheritdoc cref="Terms.SatelliteOperationType"/>
    [Field(25, 26)]
    public Terms.SatelliteOperationType OperationType { get; set; }

    /// <inheritdoc cref="Terms.SatelliteService"/>
    [Field(29, 30)]
    public Terms.SatelliteService Service { get; set; }

    /**<summary>
    <c>HAL</c> field.
    </summary>
    <value>Meters.</value>
    <remarks>See section 5.263.</remarks>*/
    [Field(110, 112), Float(10)]
    public float HorizontalAlert { get; set; }

    /**<summary>
    <c>VAL</c> field.
    </summary>
    <value>Meters.</value>
    <remarks>See section 5.264.</remarks>*/
    [Field(113, 115), Float(10)]
    public float VerticalAlert { get; set; }
}
