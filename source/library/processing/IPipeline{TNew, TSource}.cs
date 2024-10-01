using Arinc424.Building;

namespace Arinc424.Processing;

internal interface IPipeline<TSource> where TSource : Record424
{
    IEnumerable<Build> Process(Queue<Build<TSource>> builds);

    static abstract Type OutType { get; }
}

internal interface IPipeline<TNew, TSource> : IPipeline<TSource> where TNew : Record424 where TSource : Record424
{
    new IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds);

    IEnumerable<Build> IPipeline<TSource>.Process(Queue<Build<TSource>> builds) => Process(builds);

    static Type IPipeline<TSource>.OutType => typeof(TNew);
}
