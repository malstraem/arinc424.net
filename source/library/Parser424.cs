using System.Reflection;

namespace Arinc424;

using Linking;
using Diagnostics;

internal class Parser424
{
    private readonly Dictionary<Section, Queue<string>> records = [];

    internal readonly Meta424 meta;

    internal readonly Builds middle = [];

    /// <summary>Storage for entity builds. Covers bare types and compositions.</summary>
    internal readonly Dictionary<Section, Builds> builds = [];

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
    {
#if !NOPARALLEL
        Parallel.ForEach(meta.Info, x =>
        {
            var (section, info) = (x.Key, x.Value);

            builds[section][info.Composition.Low] = info.Build(records[section]);
        });
#else
        foreach (var (section, info) in meta.Info)
            builds[section][info.Composition.Low] = info.Build(records[section]);
#endif
        foreach (var (type, info) in meta.MiddleInfo)
        {
            Queue<Build> middles = [];

            foreach (var section in info.Item2)
            {
                foreach (var build in builds[section][meta.Info[section].Composition.Top])
                    middles.Enqueue(build);
            }
            middle[type] = middles;
        }
    }

    private void Process()
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

    private Data424 GetData(out Queue<Build> invalid)
    {
        invalid = [];

        Data424 data = new();

        Dictionary<Record424, Diagnostic[]> diagnostics = [];

        var method = typeof(Parser424).GetMethod("Process", BindingFlags.NonPublic | BindingFlags.Static);

        foreach (var (property, section) in Data424.GetProperties())
        {
            var process = method!.MakeGenericMethod([property.PropertyType.GetElementType()!]);

            property.SetValue(data, process.Invoke(null, [builds[section].Values.Last(), diagnostics]));
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

    internal static TRecord[] Process<TRecord>(Queue<Build<TRecord>> builds, Dictionary<Record424, Diagnostic[]> invalid)
        where TRecord : Record424
    {
        Queue<TRecord> records = [];

        Queue<Diagnostic> diagnostics = [];

        while (builds.TryDequeue(out var build))
        {
            records.Enqueue(build.Record);

            Hold(build);

            if (diagnostics.Count > 0)
            {
                invalid.Add(build.Record, [.. diagnostics]);
                diagnostics.Clear();
            }
        }
        return [.. records];

        void Hold(Build build)
        {
            if (build.Diagnostics is not null)
                diagnostics.Pump(build.Diagnostics);

            if (build is ISequentBuild sequent)
            {
                foreach (var sequence in sequent.Builds)
                    Hold(sequence);
            }
        }
    }

    internal Data424 Parse(IEnumerable<string> strings, out string[] skipped, out Queue<Build> invalid)
    {
        skipped = Process(strings);

        Build();
        Process();
        Link();

        return GetData(out invalid);
    }
}
