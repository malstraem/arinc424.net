namespace Arinc424.Comms;

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
