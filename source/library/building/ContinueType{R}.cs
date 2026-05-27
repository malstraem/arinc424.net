using System.Runtime.CompilerServices;

namespace Arinc424.Building;

/**<summary>
How an entity (continuation record) should be created and processed.
</summary>*/
internal abstract class ContinueType
{
    internal static ContinueType Create(Type type, Supplement supplement)
    {
        var constructor = typeof(ContinueType<>)
            .MakeGenericType(type)
                .GetConstructor([typeof(Supplement)])!;

        return (ContinueType)constructor.Invoke([supplement]);
    }

    internal abstract Queue<Build> Build(Queue<string> strings);
}

internal class ContinueType<R>(Supplement supplement)
    : ContinueType
        where R : Record424
{
    private readonly BuildInfo<R> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<R>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
            builds.Enqueue(RecordBuilder<R>.Build(@string, info, ref diagnostics));

        return Unsafe.As<Queue<Build>>(builds);
    }
}
