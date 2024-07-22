using Arinc424.Airspace;
using Arinc424.Building;

namespace Arinc424.Processing;

internal abstract class FlightRegionConcatanater : IProcessor<FlightRegion, RegionVolume>
{
    internal static bool Trigger(RegionVolume current, RegionVolume next) => current.Identifier != next.Identifier;

    private static FlightRegion New(RegionVolume sub) => new()
    {
        Name = sub.Name,
        Address = sub.Address,
        Identifier = sub.Identifier
    };

    public static IEnumerable<Build<FlightRegion>> Process(Queue<Build<RegionVolume>> records)
        => Concatenater<FlightRegion, RegionVolume>.Concat(records, New, Trigger);
}
