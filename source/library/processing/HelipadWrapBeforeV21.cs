namespace Arinc424.Processing;

using Ground;
using Building;
using Diagnostics;

/**<summary>
<see cref="Pad"/> record did not exist prior to supplement 21, so this pipeline creates <see cref="Heliport">heliports</see>
with associated helipads (only have identifier).
</summary>*/
internal sealed class PadWrapBeforeV21 : Scan<Heliport, Heliport>
{
    /// <summary>Heliport identifier range.</summary>
    private readonly Range range = 7..10;

    protected override bool Trigger(Heliport current, Heliport next) => current.Source![range] != next.Source![range];

    protected override Build<Heliport> Build(Queue<Build<Heliport>> builds, ref Queue<Diagnostic> _)
    {
        var build = builds.First();

        Queue<Pad> pads = [];

        while (builds.TryDequeue(out var source))
        {
            var port = source.Record;

            pads.Enqueue(new Pad
            {
                Source = port.Source,
                Code = port.Code,
                Icao = port.Icao,
                Identifier = port.Source![range].Trim(),
                Number = port.Number,
                Port = port
            });
        }
        build.Record.Pads = [.. pads];
        return build;
    }
}
