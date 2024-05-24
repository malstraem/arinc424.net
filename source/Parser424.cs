using System.Collections;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Meta424 meta = new();

    private readonly Queue<string> skipped = [];

    private readonly Dictionary<Type, Queue<string>> primary = [];
    private readonly Dictionary<Type, Queue<string>> continuation = [];

    private readonly Dictionary<Type, Queue<Record424>> records = [];

    internal Parser424()
    {
        foreach (var (_, type) in meta.Types)
        {
            records[type] = [];
            primary[type] = [];
            continuation[type] = [];
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

                if (info.ContinuationIndex is null)
                {
                    primary[type].Enqueue(@string);
                }
                else
                {
                    int index = info.ContinuationIndex.Value;

                    (@string[index] is '0' or '1' ? primary[type] : continuation[type]).Enqueue(@string);
                }
                return true;
            }
            return false;
        }
    }

    [Obsolete("todo: try parse sequence number")]
    private void BuildSequences()
    {
        _ = Parallel.ForEach(meta.Sequences, attribute =>
        {
            var queue = records[attribute.Type];
            var strings = primary[attribute.Type];

            Queue<string> sequence = [];

            while (strings.TryDequeue(out string? @string))
            {
                sequence.Enqueue(@string);

                int number = int.Parse(@string[attribute.Range]);

                if (!strings.TryPeek(out @string) || int.Parse(@string[attribute.Range]) <= number)
                    queue.Enqueue(attribute.Build(sequence));
            }
        });
    }

    private void Build()
    {
        _ = Parallel.ForEach(meta.Records, attribute =>
        {
            var queue = records[attribute.Type];
            var strings = primary[attribute.Type];

            while (strings.TryDequeue(out string? @string))
                queue.Enqueue(attribute.Build(@string, out _));
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

            while (records[type].TryDequeue(out var record))
                _ = list.Add(record);
        });
        return data;
    }
}
