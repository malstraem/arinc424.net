using Arinc424.Building;
using Arinc424.Diagnostics;
using Arinc424.Ground;

namespace Arinc424.Processing;

/// <summary>
/// <see cref="Helipad"/> record did not exist prior to supplement 21, so this pipeline creates <see cref="Heliport">heliports</see>
/// with associated helipads (only have identifier).
/// </summary>
internal sealed class HelipadWrapBeforeV21 : Scan<Heliport, Heliport>
{
    protected override bool Trigger(Heliport current, Heliport next) => current.Source![range] != next.Source![range];

    /// <summary>
    /// Helipad identifer range before supplement 21.
    /// </summary>
    private readonly Range range = 16..21;

    [Obsolete("todo: use build info")]
    protected override Build<Heliport> Build(Queue<Build<Heliport>> builds, ref Queue<Diagnostic> _)
    {
        var build = builds.First();

        var helipads = build.Record.Helipads = [];

        while (builds.TryDequeue(out var source))
        {
            var port = source.Record;

            helipads.Add(new Helipad
            {
                Source = port.Source,
                Code = port.Code,
                Icao = port.Icao,
                Identifier = port.Source![range].Trim(),
                Number = port.Number,
                Heliport = port
            });
        }
        return build;
    }
}
