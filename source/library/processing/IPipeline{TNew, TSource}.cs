using System.Runtime.CompilerServices;

using Arinc424.Building;

namespace Arinc424.Processing;

internal interface IPipeline
{
    Queue<Build> Process(Queue<Build> builds);
}

internal interface IPipeline<TSource> : IPipeline where TSource : Record424
{
    Queue<Build> Process(Queue<Build<TSource>> builds);

    /* guarantee by design */
    Queue<Build> IPipeline.Process(Queue<Build> builds) => Process(Unsafe.As<Queue<Build<TSource>>>(builds));

    static abstract Type OutType { get; }
}

internal interface IPipeline<TNew, TSource> : IPipeline<TSource> where TNew : Record424 where TSource : Record424
{
    new Queue<Build<TNew>> Process(Queue<Build<TSource>> builds);

    /* guarantee by design */
    Queue<Build> IPipeline<TSource>.Process(Queue<Build<TSource>> builds) => Unsafe.As<Queue<Build>>(Process(builds));

    static Type IPipeline<TSource>.OutType => typeof(TNew);
}
