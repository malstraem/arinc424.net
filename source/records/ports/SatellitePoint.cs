using Arinc424.Ports.Terms;

namespace Arinc424.Ports;

public abstract class SatellitePoint : PathPoint
{
    /// <inheritdoc cref="SatelliteService"/>
    [Field(29, 30)]
    public SatelliteService Service { get; set; }

    /// <summary>
    /// <c>HAL</c> field.
    /// </summary>
    /// <remarks>See section 5.263.</remarks>
    [Field(110, 112), Float(10)]
    public float HorizontalAlert { get; set; }

    /// <summary>
    /// <c>VAL</c> field.
    /// </summary>
    /// <remarks>See section 5.264.</remarks>
    [Field(113, 115), Float(10)]
    public float VerticalAlert { get; set; }
}
