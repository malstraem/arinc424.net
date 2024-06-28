using System.Collections;
using System.Collections.Concurrent;

using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Meta424 meta = new();

    private readonly Queue<string> skipped = [];

    private readonly ConcurrentDictionary<Type, IEnumerable<Build>> builds = [];

    private readonly Dictionary<Type, (Queue<string> Primary, Queue<string> Continuation)> strings = [];

    private void Process(IEnumerable<string> strings)
    {
        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skipped.Enqueue(@string);
        }

        // Checks that one of info matches the string and enqueue the matched to an associated queue.
        // (branching, apparently, will not give any tangible gain)
        bool TryEnqueue(string @string)
        {
            foreach (var info in meta.Info)
            {
                if (!info.IsMatch(@string))
                    continue;

                (info.IsContinuation(@string) ? this.strings[info.Type].Continuation : this.strings[info.Type].Primary).Enqueue(@string);
                return true;
            }
            return false;
        }
    }

    private void Build() => Parallel.ForEach(meta.Info, info => builds[info.Type] = info.Build(strings[info.Type].Primary));

    private void Link()
    {
        var unique = new Unique(meta.Info, builds);

        _ = Parallel.ForEach(meta.Info, info => info.Link(builds[info.Type], unique, meta));
    }

    internal Parser424()
    {
        foreach (var info in meta.Info)
            strings[info.Type] = ([], []);
    }

    internal Data424 Parse(IEnumerable<string> strings)
    {
        Process(strings);
        Build();
        Link();

        var data = new Data424();

        _ = Parallel.ForEach(typeof(Data424).GetProperties(), property =>
        {
            var type = property.PropertyType.GetGenericArguments().First();

            var list = (IList)property.GetValue(data)!;

            foreach (var build in builds[type])
                _ = list.Add(build.Record);
        });
        return data;
    }
}
