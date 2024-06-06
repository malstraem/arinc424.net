using System.Collections;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Meta424 meta = new();

    private readonly Queue<string> skipped = [];

    private readonly Dictionary<Type, (Queue<string> Primary, Queue<string> Continuation)> strings = [];

    private readonly Dictionary<Type, Queue<Build>> builds = [];

    internal Parser424()
    {
        foreach (var (_, type) in meta.Types)
        {
            builds[type] = [];
            strings[type] = ([], []);
        }
    }

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
                if (!info.Section.IsMatch(@string))
                    continue;

                (info.IsContinuation(@string) ? this.strings[type].Continuation : this.strings[type].Primary).Enqueue(@string);
                return true;
            }
            return false;
        }
    }

    private static void Enqueue(Record424 record, Queue<Build> builds, ref Queue<Diagnostic> diagnostics)
    {
        if (diagnostics.Count > 0)
        {
            builds.Enqueue(new(record, diagnostics));
            diagnostics = [];
        }
        else
        {
            builds.Enqueue(new(record, null));
        }
    }

    [Obsolete("todo: try parse sequence number")]
    private void BuildSequences()
    {
        _ = Parallel.ForEach(meta.Sequences, attribute =>
        {
            var queue = builds[attribute.Type];
            var primary = strings[attribute.Type].Primary;

            Queue<string> sequence = [];
            Queue<Diagnostic> diagnostics = [];

            while (primary.TryDequeue(out string? @string))
            {
                sequence.Enqueue(@string);

                int number = int.Parse(@string[attribute.Range]);

                if (!primary.TryPeek(out @string) || int.Parse(@string[attribute.Range]) <= number)
                    Enqueue(attribute.Build(sequence, diagnostics), queue, ref diagnostics);
            }
        });
    }

    private void Build()
    {
        _ = Parallel.ForEach(meta.Records, attribute =>
        {
            var queue = builds[attribute.Type];
            var primary = strings[attribute.Type].Primary;

            Queue<Diagnostic> diagnostics = [];

            while (primary.TryDequeue(out string? @string))
                Enqueue(attribute.Build(@string, diagnostics), queue, ref diagnostics);
        });
        BuildSequences();
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

            while (builds[type].TryDequeue(out var record))
                _ = list.Add(record.Record);
        });
        return data;
    }
}
