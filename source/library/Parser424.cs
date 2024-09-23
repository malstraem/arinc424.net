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
    {
        /*foreach (var info in meta.Info)
            builds[info.Section] = info.Build(strings[info.Section].Primary);*/

        _ = Parallel.ForEach(meta.Info, info => builds[info.Section] = info.Build(strings[info.Section].Primary));
    }

    private void Link(Unique unique)
    {
        _ = Parallel.ForEach(meta.Info, info => info.Link(builds[info.Section], unique, meta));
    }

    internal Parser424(Supplement supplement)
    {
        meta = new(supplement);

        foreach (var info in meta.Info)
            strings[info.Section] = ([], []);
    }

    internal Data424 Parse(IEnumerable<string> strings)
    {
        Process(strings);

        Build();

        Link(new Unique(meta.Info, builds));

        ConcurrentBag<Build> invalid = []; // todo api

        var data = new Data424();

        _ = Parallel.ForEach(Data424.GetProperties(), property =>
        {
            var type = property.Key.PropertyType.GetGenericArguments().First();

            var list = (IList)property.Key.GetValue(data)!;

            foreach (var build in builds[property.Value])
            {
                if (build.Diagnostics is null)
                {
                    _ = list.Add(build.Record);
                    continue;
                }
                invalid.Add(build);
            }
        });
        return data;
    }
}
