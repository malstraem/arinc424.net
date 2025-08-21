using System.Collections.Frozen;
using System.Reflection;

namespace Arinc424;

using Linking;
using Building;

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

        var sections = meta.Types.Values.SelectMany(x => x.Sections).ToArray();

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

            foreach (var section in sections)
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
        Parallel.ForEach(meta.Types, x =>
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
        var records = meta.Base.Values.Where(x => x is RecordType).ToArray();

        foreach (var section in records.SelectMany(x => x.Sections))
        {
            foreach (var (type, builds) in builds[section.Value])
            {
                if (!this.aggregate.TryGetValue(type, out var aggregate))
                    this.aggregate[type] = aggregate = [];

                foreach (var build in builds)
                    aggregate.Enqueue(build);
            }
        }

        var @base = meta.Base.Values.Except(records).ToArray();

        foreach (var info in @base)
        {
            if (!this.aggregate.TryGetValue(info.Top, out var aggregate))
                this.aggregate[info.Top] = aggregate = [];

            foreach (var section in info.Sections)
            {
                foreach (var build in builds[section.Value][meta.Types[section.Value].Top])
                    aggregate.Enqueue(build);
            }
        }
    }

    private void Build()
    {
#if !NOPARALLEL
        Parallel.ForEach(meta.Types, x =>
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
                .SelectMany(x => x.Relations!).ToArray();
#if !NOPARALLEL
        Parallel.ForEach(relations, x => x.Link(aggregate[x.Type], unique, meta));
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

    private Data424 GetData(out Invalid invalid)
    {
        Data424 data = new();

        Dictionary<Record424, Diagnostic[]> diagnostics = [];

        var method = typeof(Parser424).GetMethod("Process", BindingFlags.NonPublic | BindingFlags.Static);

        foreach (var (property, section) in Data424.GetProperties())
        {
            var process = method!.MakeGenericMethod([property.PropertyType.GetElementType()!]);

            property.SetValue(data, process.Invoke(null, [builds[section].Values.Last(), diagnostics]));
        }
        invalid = diagnostics.ToFrozenDictionary();
        return data;
    }

    internal Parser424(Meta424 meta)
    {
        this.meta = meta;

        foreach (var (section, _) in meta.Types)
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

    internal Data424 Parse(IEnumerable<string> strings, out string[] skipped, out Invalid invalid)
    {
        skipped = Process(strings);
        Build();
        Link();
        return GetData(out invalid);
    }
}
