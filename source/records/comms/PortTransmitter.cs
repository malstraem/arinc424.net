using Arinc424.Attributes;
using Arinc424.Converters;

namespace Arinc424.Comms;

using Terms;

public class PortTransmitter : Transmitter
{
    /// <inheritdoc cref="Terms.SectorIndicator"/>
    [Character(68), Transform<SectorIndicatorConverter>]
    public SectorIndicator SectorIndicator { get; set; }

    /// <inheritdoc cref="Terms.Sector"/>
    [Field(69, 74), Decode<SectorConverter>]
    public Sector? Sector { get; set; }

    [Type(81, 82)]
    [Foreign(75, 80)]
    public Geo? Facility { get; set; }

    /// <inheritdoc cref="DistanceLimitation"/>
    [Character(90), Transform<DistanceLimitationConverter>]
    public DistanceLimitation Limitation { get; set; }

    /// <summary>
    /// <c>Communications Distance (COMM DIST)</c> field.
    /// </summary>
    /// <value>Nautical miles.</value>
    /// <remarks>See section 5.188.</remarks>
    [Field(91, 92), Decode<IntConverter>]
    public int Distance { get; set; }

    /// <inheritdoc cref="PortCommUsages"/>
    [Field(112, 114), Decode<PortCommUsagesConverter>]
    public PortCommUsages Usages { get; set; }
}
