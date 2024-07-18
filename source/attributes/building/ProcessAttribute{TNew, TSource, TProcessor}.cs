using Arinc424.Building;
using Arinc424.Linking;
using Arinc424.Processing;

namespace Arinc424.Attributes;

internal abstract class ProcessAttribute<TSource>(Type newType, Supplement start, Supplement end) : SupplementAttribute(start, end)
    where TSource : Record424, new()
{
    internal abstract Relations GetRelations(Supplement supplement);

    internal abstract IEnumerable<Build> Process(Queue<Build<TSource>> builds);

    internal Type NewType { get; } = newType;
}

internal class ProcessAttribute<TNew, TSource, TProcessor>(Supplement start = Supplement.V18, Supplement end = Supplement.V23)
    : ProcessAttribute<TSource>(typeof(TNew), start, end)
    where TNew : Record424, new()
    where TSource : Record424, new()
    where TProcessor : IProcessor<TNew, TSource>
{
    internal override Relations<TNew> GetRelations(Supplement supplement) => new(supplement);

    internal override IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds) => TProcessor.Process(builds);
}
