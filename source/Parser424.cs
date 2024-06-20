using System.Collections;

using Arinc424.Building;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Meta424 meta = new();

    private readonly Queue<string> skipped = [];

    private readonly Dictionary<Type, Queue<Build>> builds = [];

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
            foreach (var (type, info) in meta.Info)
            {
                if (!info.IsMatch(@string))
                    continue;

                (info.IsContinuation(@string) ? this.strings[type].Continuation : this.strings[type].Primary).Enqueue(@string);
                return true;
            }
            return false;
        }
    }

    private void Build() => Parallel.ForEach(meta.Builds, attribute => builds[attribute.Type] = attribute.Build(strings[attribute.Type].Primary));

    internal Parser424()
    {
        foreach (var (_, type) in meta.Types)
        {
            builds[type] = [];
            strings[type] = ([], []);
        }
    }

    internal Data424 Parse(IEnumerable<string> strings)
    {
        Process(strings);
        Build();
        Postprocess();
        //Link();

        var data = new Data424();

        _ = Parallel.ForEach(typeof(Data424).GetProperties(), property =>
        {
            var type = property.PropertyType.GetGenericArguments().First();

            var list = (IList)property.GetValue(data)!;

            while (builds[type].TryDequeue(out var record))
                _ = list.Add(record.Record);
        });
        return data;
    }
}
