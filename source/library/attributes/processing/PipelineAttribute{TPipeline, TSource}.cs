using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class PipelineAttribute(Type outType, Supplement start, Supplement end) : SupplementAttribute(start, end)
{
    internal abstract IPipeline GetPipeline(Supplement supplement);

    internal Type OutType { get; } = outType;
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class PipelineAttribute<TPipeline, TSource>(Supplement start = Supplement.V18, Supplement end = Supplement.V23)
    : PipelineAttribute(TPipeline.OutType, start, end)
        where TSource : Record424
        where TPipeline : IPipeline<TSource>
{
    internal override IPipeline<TSource> GetPipeline(Supplement supplement)
    {
        var type = typeof(TPipeline);

        var constructor = type.GetConstructor([typeof(Supplement)]);

        /* guarantee by design */
        return (IPipeline<TSource>)
                (constructor is null
                    ? type.GetConstructor([])!.Invoke(null)
                    : constructor.Invoke([supplement]));
    }
}
