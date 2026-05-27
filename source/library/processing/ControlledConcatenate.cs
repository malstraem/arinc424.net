namespace Arinc424.Processing;

using Airspace;
using Building;

internal class ControlledConcatenate(Supplement supplement)
    : IPipeline<ControlledSpace, Controlled>
{
    /// <summary><see cref="Space{V}.Name"/> range.</summary>
    private readonly Range range = 93..123;

    private readonly BuildInfo<ControlledSpace> info = new(supplement);

    public Queue<Build<ControlledSpace>> Process(Queue<Build<Controlled>> builds)
    {
        Queue<Build<ControlledSpace>> spaces = [];

        if (builds.Count == 0)
            return spaces;

        Queue<Diagnostic> diagnostics = [];

        Dictionary<string, Queue<Build<Controlled>>> buffer = [];

        foreach (var build in builds)
        {
            string name = build.Record.Source![range].Trim();

            if (!buffer.TryGetValue(name, out var volumes))
                volumes = buffer[name] = [];

            volumes.Enqueue(build);
        }

        foreach (var (name, volumes) in buffer)
            spaces.Enqueue(RecordBuilder<ControlledSpace, Controlled>.Build(volumes, info, ref diagnostics));

        return spaces;
    }
}
