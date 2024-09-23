using Arinc424.Building;
using Arinc424.Ground;

namespace Arinc424.Processing;

/// <summary>
/// <see cref="Helipad"/> record did not exist prior to supplement 21,
/// so this pipeline creates <see cref="Heliport"/>'s with associated helipads (only have identifier).
/// </summary>
[Obsolete("try to generalize 'scanner' logic")]
internal class HelipadWrapBeforeV21 : IPipeline<Heliport, Heliport>
{
    public IEnumerable<Build<Heliport>> Process(Queue<Build<Heliport>> builds)
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
            Code = port.Code,
            Icao = port.Icao,
            Identifier = port.Source![16..20].Trim(), //it's Helipad identifer range before supplement 21.
            Number = port.Number,
            Heliport = port
        };
    }
}
