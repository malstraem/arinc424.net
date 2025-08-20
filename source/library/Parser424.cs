using System.Reflection;

namespace Arinc424;

using Linking;
using Diagnostics;

internal class Parser424
{
    private readonly Dictionary<Section, Queue<string>> records = [];

    internal readonly Meta424 meta;

    internal readonly Builds aggregate = [];

    /**<summary>
    Storage for entity builds. Covers bare types and compositions.
    </summary>*/
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

    private void Process()
    {
#if !NOPARALLEL
        Parallel.ForEach(meta.Info, x =>
        {
            var (section, info) = (x.Key, x.Value);

            var pipes = info.Pipes;

            if (pipes is null)
                return;

            var builds = this.builds[section];

            foreach (var pipe in pipes)
                builds[pipe.OutType] = pipe.Process(builds[pipe.SourceType]);
        });
#else
        foreach (var (section, info) in meta.Info)
        {
            var pipes = info.Pipes;

            if (pipes is null)
                continue;

            var builds = this.builds[section];

            foreach (var pipe in pipes)
                builds[pipe.OutType] = pipe.Process(builds[pipe.SourceType]);
        }
#endif
    }

    private void Aggregate()
    {
        foreach (var (type, info) in meta.Base)
        {
            var aggregate = this.aggregate[type];

            foreach (var section in info.Sections.Select(x => x.Value))
            {
                var builds = this.builds[section];

                foreach (var comp in info.Composition)
                {
                    foreach (var build in builds[comp])
                        aggregate.Enqueue(build);
                }
            }
        }
    }

    private void Build()
    {
#if !NOPARALLEL
        Parallel.ForEach(meta.Info, x =>
        {
            var (section, info) = (x.Key, x.Value);

            builds[section][info.Low] = info.Build(records[section]);
        });
#else
        foreach (var (section, info) in meta.Info)
            builds[section][info.Low] = info.Build(records[section]);
#endif
        Process();
        Aggregate();
    }

    private void Link()
    {
        Unique unique = new(this);

        var relations = meta.Base.Values
            .Where(x => x.Relations is not null)
                .SelectMany(x => x.Relations!);
#if !NOPARALLEL
        Parallel.ForEach(relations, relation => relation.Link(aggregate[relation.Type], unique, meta));
        Parallel.ForEach(relations, x => x.Aggregate(aggregate));
#else
        foreach (var (section, info) in meta.Info)
        {
            var relations = info.Composition.Relations;

            if (relations is null)
                continue;

            foreach (var relation in relations)
                relation.Link(builds[section][relation.Type], unique, meta);
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

        foreach (var (type, _) in meta.Base)
            aggregate[type] = [];
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
        Link();
        return GetData(out invalid);
    }
}
