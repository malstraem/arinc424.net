using System.Runtime.CompilerServices;

using Arinc424.Diagnostics;

namespace Arinc424.Building;

/**<summary>
How an entity (continuation record) should be created and processed.
</summary>*/
internal abstract class ContinuationInfo
{
    internal static ContinuationInfo Create(Type type, Supplement supplement)
    {
        var constructor = typeof(ContinuationInfo<>)
            .MakeGenericType(type)
                .GetConstructor([typeof(Supplement)])!;

        return (ContinuationInfo)constructor.Invoke([supplement]);
    }

    internal abstract Queue<Build> Build(Queue<string> strings);
}

internal class ContinuationInfo<TRecord>(Supplement supplement) : ContinuationInfo where TRecord : Record424, new()
{
    private readonly BuildInfo<TRecord> info = new(supplement);

    internal override Queue<Build> Build(Queue<string> strings)
    {
        Queue<Diagnostic> diagnostics = [];

        Queue<Build<TRecord>> builds = new(strings.Count);

        while (strings.TryDequeue(out string? @string))
            builds.Enqueue(RecordBuilder<TRecord>.Build(@string, info, ref diagnostics));

        return Unsafe.As<Queue<Build>>(builds);
    }
}
