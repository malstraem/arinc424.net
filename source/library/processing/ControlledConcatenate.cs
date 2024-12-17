using Arinc424.Airspace;
using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Processing;

internal class ControlledConcatenate(Supplement supplement) : IPipeline<ControlledSpace, ControlledVolume>
{
    /// <summary>
    /// <see cref="Space{TVolume}.Name"/> range.
    /// </summary>
    private readonly Range range = 93..123;

    private readonly BuildInfo<ControlledSpace> info = new(supplement);

    public Queue<Build<ControlledSpace>> Process(Queue<Build<ControlledVolume>> builds)
    {
        Queue<Build<ControlledSpace>> spaces = [];

        if (builds.Count == 0)
            return spaces;

        Queue<Diagnostic> diagnostics = [];

        Dictionary<string, Queue<Build<ControlledVolume>>> buffer = [];

        foreach (var build in builds)
        {
            string name = build.Record.Source![range].Trim();

            if (!buffer.TryGetValue(name, out var volumes))
                volumes = buffer[name] = [];

            volumes.Enqueue(build);
        }

        foreach (var (name, volumes) in buffer)
            spaces.Enqueue(RecordBuilder<ControlledSpace, ControlledVolume>.Build(volumes, info, ref diagnostics));

        return spaces;
    }
}
