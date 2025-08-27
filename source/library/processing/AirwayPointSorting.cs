namespace Arinc424.Processing;

using Routing;
using Building;

/**<summary>
The <see cref="AirwayPoint"/> records may be split into different sequences by <see cref="Record424.Code"/> while assembly file sorting.
So this pipeline resort all points using airway identifier.
</summary>*/
internal class AirwayPointSorting : IPipeline<AirwayPoint, AirwayPoint>
{
    /// <summary>Airway identifier range.</summary>
    private readonly Range range = 13..18;

    public Queue<Build<AirwayPoint>> Process(Queue<Build<AirwayPoint>> builds)
    {
        if (builds.Count == 0)
            return builds;

        var sorted = builds.OrderBy(x => x.Record.Source![range]);

        return new(sorted);
    }
}
