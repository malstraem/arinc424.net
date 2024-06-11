namespace Arinc424.Ports.Terms;

/// <summary>
/// <c>Operation Type (OPS TYPE)</c> field, specific for <see cref="AirportSatellitePoint"/>
/// </summary>
/// <remarks>See section 5.223.</remarks>
[String, Decode<SatelliteOperationTypeConverter, SatelliteOperationType>]
public enum SatelliteOperationType : byte
{
    Unknown,
    /// <summary>
    /// Straight-in or point-in-space approach procedure.
    /// </summary>
    [Map("00")] Straight
}
