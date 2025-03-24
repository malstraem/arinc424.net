using System.Reflection;
using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;
using Arinc424.Linking;

namespace Arinc424.Building;

/// <summary>How an entity should be created and processed.</summary>
internal abstract class RecordInfo(Composition composition, Continuations? continuations, SectionAttribute[] sections)
{
    internal static RecordInfo Create(Type type, Supplement supplement)
    {
        var composition = type.GetComposition(supplement);

        var continuations = Continuations.Create(composition, supplement);

        // take only low level composition type
        var constructor = typeof(RecordInfo<>)
            .MakeGenericType(composition.Low)
                .GetConstructor([typeof(Supplement), typeof(Composition), typeof(Continuations), typeof(SectionAttribute[])])!;

        var secitons = type.GetCustomAttributes<SectionAttribute>(false).ToArray(); // take only top level attributes

        var info = (RecordInfo)constructor.Invoke([supplement, composition, continuations, secitons]);

        return info;
    }

    internal static RecordInfo Create<TRecord>(Supplement supplement) where TRecord : Record424, new() => Create(typeof(TRecord), supplement);

    internal abstract Queue<Build> Build(Queue<string> strings);

    internal Primary? Primary { get; } = Primary.Create(composition.Top);

    internal Composition Composition { get; } = composition;

    internal Continuations? Continuations { get; } = continuations;

    internal Relationships? Relations { get; } = composition.Relations.FirstOrDefault(x => x.Type == composition.Top);

    internal SectionAttribute[] Sections { get; } = sections;
}

internal sealed class RecordInfo<TRecord>(Supplement supplement, Composition composition, Continuations? continuations, SectionAttribute[] sections)
    : RecordInfo(composition, continuations, sections) where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        Build<TRecord> build;

        if (strings.TryDequeue(out string? @string))
        {
            Build(@string);
        }
        else
        {
            return Unsafe.As<Queue<Build>>(builds);
        }

        while (strings.TryDequeue(out @string))
        {
            if (Continuations is not null && Continuations.TryProcess(@string))
                continue;

            Build(@string);

            Continuations?.Set(build.Record);
        }
        return Unsafe.As<Queue<Build>>(builds);

        void Build(string @string)
        {
            build = RecordBuilder<TRecord>.Build(@string, info, ref diagnostics);
            builds.Enqueue(build);
        }
    }
}
