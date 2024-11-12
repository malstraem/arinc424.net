using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424;

internal class Parser424
{
    private readonly Meta424 meta;

    /// <summary>
    /// Storage for entity builds. Covers bare types and compositions.
    /// </summary>
    private readonly Dictionary<Section, Dictionary<Type, Queue<Build>>> builds = [];

    private readonly Dictionary<Section, (Queue<string> Primary, Queue<string> Continuation)> strings = [];

    private void Process(IEnumerable<string> strings, Queue<string> skipped)
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
        => Parallel.ForEach(meta.Info, info => builds[info.Section][info.Type] = info.Build(strings[info.Section].Primary));
#else
    {
        foreach (var info in meta.Info)
            builds[info.Section] = info.Build(strings[info.Section].Primary);
    }
#endif
    private void Link(Unique unique)
#if !NOPARALLEL
        => Parallel.ForEach(meta.Info, info => info.Link(builds[info.Section][info.Type], unique, meta));
#else
    {
        foreach (var info in meta.Info)
            info.Link(builds[info.Section], unique, meta);
    }
#endif
    private void Postprocess()
    {
        foreach (var info in meta.Info)
        {
            if (info.CompositionPipelines is not null)
            {
                var builds = this.builds[info.Section];

                foreach (var (sourceType, outType, pipeline) in info.CompositionPipelines)
                {
                    builds[outType] = pipeline.Process(builds[sourceType]);
                }

                //this.builds[info.Section] = builds;
            }
        }
    }

    internal Parser424(Meta424 meta)
    {
        this.meta = meta;

        foreach (var info in meta.Info)
        {
            builds[info.Section] = [];
            strings[info.Section] = ([], []);
        }
    }

    internal Data424 Parse(IEnumerable<string> strings, out Queue<string> skipped, out Queue<Build> invalid)
    {
        skipped = [];
        invalid = [];

        Process(strings, skipped);
        Build();
        Postprocess();
        //Link(new Unique(meta.Info, builds));

        var data = new Data424();

        /*foreach (var (property, section) in Data424.GetProperties())
        {
            var list = (IList)property.GetValue(data)!;

            foreach (var build in builds[section])
            {
                if (build.Diagnostics is null)
                    _ = list.Add(build.Record);
                else
                    invalid.Enqueue(build);
            }
        }*/
        return data;
    }
}
