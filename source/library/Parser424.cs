using System.Collections;
using System.Collections.Concurrent;

using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Meta424 meta;

    private readonly Queue<string> skipped = [];

    private readonly ConcurrentDictionary<Section, IEnumerable<Build>> builds = [];

    private readonly Dictionary<Section, (Queue<string> Primary, Queue<string> Continuation)> strings = [];

    private void Process(IEnumerable<string> strings)
    {
        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skipped.Enqueue(@string);
        }

        bool TryEnqueue(string @string)
        {
            foreach (var info in meta.Info)
            {
                if (!info.IsMatch(@string))
                    continue;

                (info.IsContinuation(@string) ? this.strings[info.Section].Continuation : this.strings[info.Section].Primary).Enqueue(@string);
                return true;
            }
            return false;
        }
    }

    private void Build()
#if !NOPARALLEL
        => Parallel.ForEach(meta.Info, info => builds[info.Section] = info.Build(strings[info.Section].Primary));
#else
    {
        foreach (var info in meta.Info)
            builds[info.Section] = info.Build(strings[info.Section].Primary);
    }
#endif
    private void Link(Unique unique)
#if !NOPARALLEL
        => Parallel.ForEach(meta.Info, info => info.Link(builds[info.Section], unique, meta));
#else
    {
        foreach (var info in meta.Info)
            info.Link(builds[info.Section], unique, meta);
    }
#endif
    internal Parser424(Meta424 meta)
    {
        this.meta = meta;

        foreach (var info in meta.Info)
            strings[info.Section] = ([], []);
    }

    internal Data424 Parse(IEnumerable<string> strings, out string[] skipped, out Build[] invalid)
    {
        Process(strings);

        Build();

        Link(new Unique(meta.Info, builds));

        ConcurrentQueue<Build> invalidBuilds = [];

        var data = new Data424();

        foreach (var controlled in data.ControlledSpaces)
        {
            foreach (var volume in controlled.Sequence)
            {
                if (volume.Center.Identifier.Last() == 'X')
                    Console.WriteLine(volume.Center.Identifier);
            }
        }

        _ = Parallel.ForEach(Data424.GetProperties(), pair =>
        {
            var list = (IList)pair.Key.GetValue(data)!;

            foreach (var build in builds[pair.Value])
            {
                if (build.Diagnostics is null)
                    _ = list.Add(build.Record);
                else
                    invalidBuilds.Enqueue(build);
            }
        });
        skipped = [.. this.skipped];
        invalid = [.. invalidBuilds];
        return data;
    }
}
