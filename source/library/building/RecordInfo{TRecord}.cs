using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Building;

#pragma warning disable CS8618
/// <summary>
/// How an entity should be created and processed.
/// </summary>
internal abstract class RecordInfo(Type type)
#pragma warning restore CS8618
{
    private int? continuationIndex;

    [Obsolete("todo")]
    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new()
    {
        var type = typeof(TRecord);

        var constructor = typeof(RecordInfo<>)
            .MakeGenericType(type.GetComposition().First())
                .GetConstructor([typeof(Type), typeof(Supplement)]);

        List<(Type, Type, IPipeline)> pipelines = [];

        foreach (var pipe in type.GetCustomAttributes<PipelineAttribute>())
        {
            if (supplement >= pipe.Start && supplement <= pipe.End)
                pipelines.Add((pipe.SourceType, pipe.OutType, pipe.GetPipeline(supplement)));
        }

        List<(Type, Relationships)> relations = [];

        foreach (var (sourceType, _, _) in pipelines)
        {
            var relationships = Relationships.Create(sourceType, supplement);

            if (relationships is not null)
                relations.Add((sourceType, relationships));
        }

        var info = (RecordInfo)constructor!.Invoke([type, supplement]);

        info.Relations = Relationships.Create(type, supplement);

        if (info.Relations is not null)
            relations.Add((type, info.Relations));

        if (relations.Count != 0)
            info.CompositionRelations = [.. relations];

        if (pipelines.Count != 0)
            info.CompositionPipelines = [.. pipelines];

        info.continuationIndex = type.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement)?.Index;

        info.Sections = type.GetCustomAttributes<SectionAttribute>(false).ToArray(); // take only top level attributes;

        return info;
    }

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';

    internal Type TopLevel { get; } = type;

    internal Type LowLevel { get; } = type.GetComposition().First();

    internal Primary? Primary { get; } = Primary.Create(type);

    internal Relationships? Relations { get; private set; }

    /// <summary>
    /// Pipelines for bare and composition types including top level.
    /// </summary>
    internal (Type, Type, IPipeline)[]? CompositionPipelines { get; private set; }

    internal (Type, Relationships)[]? CompositionRelations { get; private set; }

    internal SectionAttribute[] Sections { get; private set; }
}

internal sealed class RecordInfo<TRecord>(Type type, Supplement supplement) : RecordInfo(type) where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
        {
            if (IsContinuation(@string))
                continue;

            var build = new Build<TRecord>(RecordBuilder<TRecord>.Build(@string, info, diagnostics));

            if (diagnostics.Count != 0)
            {
                build.Diagnostics = diagnostics;
                diagnostics = [];
            }
            builds.Enqueue(build);
        }
        return Unsafe.As<Queue<Build>>(builds);
    }
}
