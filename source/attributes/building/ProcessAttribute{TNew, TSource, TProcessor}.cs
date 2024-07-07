using Arinc424.Building;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class ProcessAttribute<TSource>(Type newType) : Attribute where TSource : Record424, new()
{
    internal abstract Relations GetRelations();

    internal abstract IEnumerable<Build> Process(Queue<Build<TSource>> builds);

    internal Type NewType { get; } = newType;
}

internal class ProcessAttribute<TNew, TSource, TProcessor>() : ProcessAttribute<TSource>(typeof(TNew))
    where TNew : Record424, new()
    where TSource : Record424, new()
    where TProcessor : IProcessor<TNew, TSource>
{
    internal override Relations<TNew> GetRelations() => new();

    internal override IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds) => TProcessor.Process(builds);
}
