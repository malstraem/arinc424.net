using System.Reflection;

namespace Arinc424;

using Linking;
using Building;

internal class Parser424
{
    private readonly Dictionary<Section, Queue<string>> records = [];

    internal readonly Meta424 meta;

    /// <summary>Storage for entity builds. Covers bare types and compositions.</summary>
    internal readonly Dictionary<Section, Dictionary<Type, Queue<Build>>> builds = [];

    private string[] Process(IEnumerable<string> strings)
    {
        Queue<string> skipped = [];

        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skipped.Enqueue(@string);
        }
        return [.. skipped];

        bool TryEnqueue(string @string)
        {
            if (@string.Length < 132)
                return false;

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
            builds[section][info.Composition.Low] = info.Build(records[section]);
    }
#endif
    private void Link()
    {
        Unique unique = new(this);
#if !NOPARALLEL
        Parallel.ForEach(meta.Info, x =>
        {
            var (section, info) = (x.Key, x.Value);

            foreach (var relations in info.Composition.Relations)
                relations.Link(builds[section][relations.Type], unique, meta);
        });
#else
        foreach (var (section, info) in meta.Info)
        {
            foreach (var relations in info.Composition.Relations)
                relations.Link(builds[section][relations.Type], unique, meta);
        }
#endif
    }

    private void PostProcess()
    {
#if !NOPARALLEL
        Parallel.ForEach(meta.Info, x =>
        {
            var (section, info) = (x.Key, x.Value);

            var builds = this.builds[section];

            foreach (var pipeline in info.Composition.Pipelines)
                builds[pipeline.OutType] = pipeline.Process(builds[pipeline.SourceType]);
        });
#else
        foreach (var (section, info) in meta.Info)
        {
            var builds = this.builds[section];

            foreach (var pipeline in info.Composition.Pipelines)
                builds[pipeline.OutType] = pipeline.Process(builds[pipeline.SourceType]);
        }
#endif
    }

    private Data424 GetData(out Queue<Build> invalid)
    {
        invalid = [];

        Data424 data = new();

        var method = typeof(Parser424).GetMethod("Process", BindingFlags.NonPublic | BindingFlags.Static);

        foreach (var (property, section) in Data424.GetProperties())
        {
            var biba = method!.MakeGenericMethod([property.PropertyType.GetElementType()!]);

            property.SetValue(data, biba.Invoke(null, [builds[section].Values.Last(), invalid]));
        }
        return data;
    }

    internal Parser424(Meta424 meta)
    {
        this.meta = meta;

        foreach (var (section, _) in meta.Info)
        {
            builds[section] = [];
            records[section] = [];
        }
    }

    internal static TRecord[] Process<TRecord>(Queue<Build<TRecord>> builds, Queue<Build> invalid) where TRecord : Record424
    {
        Queue<TRecord> valid = [];

        foreach (var build in builds)
        {
            if (build.Diagnostics is null)
                valid.Enqueue(build.Record);
            else
                invalid.Enqueue(build);
        }
        return [.. valid];
    }

    internal Data424 Parse(IEnumerable<string> strings, out string[] skipped, out Queue<Build> invalid)
    {
        skipped = Process(strings);

        Build();
        PostProcess();
        Link();

        return GetData(out invalid);
    }
}
