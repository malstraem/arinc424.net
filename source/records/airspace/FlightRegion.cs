namespace Arinc424.Airspace;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {{{nameof(Name)},nq}}")]
public class FlightRegion : Record424<RegionVolume>, IIdentity, INamed
{
    /// <inheritdoc cref="RegionVolume.Address"/>
    public string Address { get; set; }

    /// <inheritdoc cref="RegionVolume.Identifier"/>
    [Field(7, 10)]
    public string Identifier { get; set; }

    /// <inheritdoc cref="RegionVolume.Name"/>
    public string? Name { get; set; }
}
