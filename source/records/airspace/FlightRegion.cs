namespace Arinc424.Airspace;

[DebuggerDisplay($"{{{nameof(Identifier)},nq}}, {{{nameof(Name)},nq}}")]
public class FlightRegion : Record424<RegionVolume>, IIdentity, IIcao, INamed
{
    /// <inheritdoc cref="RegionVolume.Address"/>
    public string Address { get; set; }

    public string IcaoCode { get; set; }

    /// <inheritdoc cref="RegionVolume.Identifier"/>
    public string Identifier { get; set; }

    /// <inheritdoc cref="RegionVolume.Name"/>
    public string? Name { get; set; }
}
