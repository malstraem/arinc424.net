using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class PipelineAttribute<TSource>(Type outType, Supplement start, Supplement end) : SupplementAttribute(start, end)
    where TSource : Record424
{
    internal abstract IPipeline<TSource> GetPipeline(Supplement supplement);

    internal Type OutType { get; } = outType;
}

internal sealed class PipelineAttribute<TPipeline, TSource>(Supplement start = Supplement.V18, Supplement end = Supplement.V23)
    : PipelineAttribute<TSource>
    (
        TPipeline.OutType, /* garantee by design */
        start, end
    )
    where TSource : Record424
    where TPipeline : IPipeline<TSource>
{
    internal override IPipeline<TSource> GetPipeline(Supplement supplement)
    {
        var type = typeof(TPipeline);

        var constructor = type.GetConstructor([typeof(Supplement)]);

        /* garantee by design */
        return (IPipeline<TSource>)
                (constructor is null
                    ? type.GetConstructor([])!.Invoke(null)
                    : constructor.Invoke([supplement]));
    }
}
