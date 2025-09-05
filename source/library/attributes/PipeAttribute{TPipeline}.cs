namespace Arinc424.Attributes;

using Processing;

internal abstract class PipeAttribute : SupplementAttribute
{
    internal abstract IPipeline GetPipeline(Supplement supplement);
}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
internal sealed class PipeAttribute<TPipeline> : PipeAttribute where TPipeline : IPipeline
{
    internal override IPipeline GetPipeline(Supplement supplement)
    {
        var type = typeof(TPipeline);

        var constructor = typeof(TPipeline).GetConstructor([typeof(Supplement)]);

        /* guarantee by design */
        return (IPipeline)
                (constructor is null
                    ? type.GetConstructor([])!.Invoke(null)
                    : constructor.Invoke([supplement]));
    }
}
