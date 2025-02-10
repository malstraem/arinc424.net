using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class PipelineAttribute : SupplementAttribute
{
    internal abstract IPipeline GetPipeline(Supplement supplement);
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class PipelineAttribute<TPipeline> : PipelineAttribute where TPipeline : IPipeline
{
    internal override IPipeline GetPipeline(Supplement supplement)
    {
        var type = typeof(TPipeline);

        var constructor = type.GetConstructor([typeof(Supplement)]);

        /* guarantee by design */
        return (IPipeline)
                (constructor is null
                    ? type.GetConstructor([])!.Invoke(null)
                    : constructor.Invoke([supplement]));
    }
}
