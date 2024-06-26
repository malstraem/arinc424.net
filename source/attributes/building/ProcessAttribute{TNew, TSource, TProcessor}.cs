using Arinc424.Building;
using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class ProcessAttribute<TSource> : Attribute where TSource : Record424, new()
{
    internal abstract IEnumerable<Build> Process(Queue<Build<TSource>> builds);

    internal abstract Type NewType { get; }
}

internal class ProcessAttribute<TNew, TSource, TProcessor> : ProcessAttribute<TSource>
    where TNew : Record424, new()
    where TSource : Record424, new()
    where TProcessor : IProcessor<TNew, TSource>
{
    internal override IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds) => TProcessor.Process(builds);

    internal override Type NewType => typeof(TNew);
}
