using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424;

internal class Parser424
{
    private readonly Meta424 meta;

    private readonly Dictionary<Section, Queue<string>> records = [];

    /// <summary>
    /// Storage for entity builds. Covers bare types and compositions.
    /// </summary>
    internal readonly Dictionary<Section, Dictionary<Type, Queue<Build>>> builds = [];

    private void Process(IEnumerable<string> strings, Queue<string> skipped)
    {
        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skipped.Enqueue(@string);
        }

        bool TryEnqueue(string @string)
        {
            foreach (var section in meta.Sections)
            {
                if (section.IsMatch(@string))
                {
                    records[section.Value].Enqueue(@string);
                    return true;
                }
            }
            return false;
        }
    }

    private void Build()
#if !NOPARALLEL
    => Parallel.ForEach(meta.Info, x =>
    {
        var (section, info) = (x.Key, x.Value);

        builds[section][info.Composition.Low] = info.Build(records[section]);
    });
#else
    {
        foreach (var (section, info) in meta.Info)
            builds[section.Value][info.LowLevel] = info.Build(records[section.Value]);
    }
#endif
    private void Link(Unique unique)
#if !NOPARALLEL
    => Parallel.ForEach(meta.Info, x =>
    {
        var (section, info) = (x.Key, x.Value);

        foreach (var realtions in info.Composition.Relations)
            realtions.Link(builds[section][realtions.Type], unique, meta);
    });
#else
    {
        foreach (var (section, info) in meta.Info)
        {
            foreach (var (type, realtions) in info.CompositionRelations)
                realtions.Link(builds[section.Value][type], unique, meta);
        }
    }
#endif
    private void Postprocess()
#if !NOPARALLEL
    => Parallel.ForEach(meta.Info, x =>
    {
        var (section, info) = (x.Key, x.Value);

        var builds = this.builds[section];

        foreach (var pipeline in info.Composition.Pipelines)
            builds[pipeline.OutType] = pipeline.Process(builds[pipeline.SourceType]);
    });
#else
    {
        foreach (var (section, info) in meta.Info)
        {
            if (info.CompositionPipelines is null)
                return;

            var builds = this.builds[section.Value];

            foreach (var (sourceType, outType, pipeline) in info.CompositionPipelines)
                builds[outType] = pipeline.Process(builds[sourceType]);
        }
    }
#endif
    internal Parser424(Meta424 meta)
    {
        this.meta = meta;

        foreach (var (section, _) in meta.Info)
        {
            builds[section] = [];
            records[section] = [];
        }
    }

    internal Data424 Parse(IEnumerable<string> strings, out Queue<string> skipped, out Queue<Build> invalid)
    {
        skipped = [];
        invalid = [];

        Process(strings, skipped);
        Build();
        Postprocess();
        Link(new Unique(meta, this));

        var data = new Data424();

        foreach (var (property, section) in Data424.GetProperties())
        {
            var list = (System.Collections.IList)property.GetValue(data)!;

            foreach (var build in builds[section].Values.Last())
            {
                if (build.Diagnostics is null)
                    _ = list.Add(build.Record);
                else
                    invalid.Enqueue(build);
            }
        }
        return data;
    }
}
