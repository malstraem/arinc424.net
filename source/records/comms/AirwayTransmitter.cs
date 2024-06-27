namespace Arinc424.Comms;

/// <summary>
/// Fields of <c>Enroute Communications</c>.
/// </summary>
/// <remarks>Used by <see cref="AirwayCommunication"/> like subsequence.</remarks>
public class AirwayTransmitter : Transmitter
{
    /// <summary>
    /// <c>Sectorization Narrative</c> field.
    /// </summary>
    /// <remarks>See section 5.186.</remarks>
    [Field(68, 92)]
    public string? Narrative { get; set; }

    /// <inheritdoc cref="Terms.AirwayCommUsages"/>
    [Field(112, 114)]
    public Terms.AirwayCommUsages Usages { get; set; }
}
