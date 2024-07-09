using Arinc424.Building;
using Arinc424.Ports;

namespace Arinc424.Processing;

/// <summary>
/// <see cref="Helipad"/> record did not exist prior to supplement 21,
/// so this post process creates <see cref="Heliport"/>'s with associated helipads (only have identifier).
/// </summary>
internal abstract class HelipadConcatenater : IProcessor<Heliport, Heliport>
{
    public static IEnumerable<Build<Heliport>> Process(Queue<Build<Heliport>> builds)
    {
        Queue<Build<Heliport>> result = new(builds.Count);

        var enumerator = builds.GetEnumerator();

        if (!enumerator.MoveNext())
            return result;

        Heliport next, current;

        List<Helipad> pads;

        result.Enqueue(new(current = enumerator.Current.Record));
        pads = current.Helipads = [GetPad(current)];

        while (enumerator.MoveNext())
        {
            next = enumerator.Current.Record;

            if (current.Identifier != next.Identifier)
            {
                result.Enqueue(new(current = next));
                pads = current.Helipads = [GetPad(current)];
                continue;
            }
            current = next;
            pads.Add(GetPad(current));
        }
        return result;

        static Helipad GetPad(Heliport port) => new Helipad
        {
            Source = port.Source,
            AreaCode = port.AreaCode,
            IcaoCode = port.IcaoCode,
            Identifier = port.Source![16..20].Trim(), //it's Helipad identifer range before supplement 21.
            RecordNumber = port.RecordNumber,
            Heliport = port
        };
    }
}
