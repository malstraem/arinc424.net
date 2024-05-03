using Arinc424.Attributes;
using Arinc424.Comms.Terms;
using Arinc424.Converters;

namespace Arinc424.Comms;

public class AirwayTransmitter : Transmitter
{
    /// <summary>
    /// <c>Sectorization Narrative</c> field.
    /// </summary>
    /// <remarks>See section 5.186.</remarks>
    [Field(68, 92)]
    public string? Narrative { get; set; }

    /// <inheritdoc cref="AirwayCommUsages"/>
    [Field(112, 114), Decode<AirwayCommUsagesConverter>]
    public AirwayCommUsages Usages { get; set; }
}
