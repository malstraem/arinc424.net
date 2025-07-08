using System.Runtime.CompilerServices;

namespace Arinc424.Processing;

using Building;

internal interface IPipeline
{
    Queue<Build> Process(Queue<Build> builds);

    Type OutType { get; }

    Type SourceType { get; }
}

internal interface IPipeline<TSource> : IPipeline where TSource : Record424
{
    Queue<Build> Process(Queue<Build<TSource>> builds);

    /* guarantee by design */
    Queue<Build> IPipeline.Process(Queue<Build> builds) => Process(Unsafe.As<Queue<Build<TSource>>>(builds));

    Type IPipeline.SourceType => typeof(TSource);
}

internal interface IPipeline<TOut, TSource> : IPipeline<TSource> where TOut : Record424 where TSource : Record424
{
    new Queue<Build<TOut>> Process(Queue<Build<TSource>> builds);

    /* guarantee by design */
    Queue<Build> IPipeline<TSource>.Process(Queue<Build<TSource>> builds) => Unsafe.As<Queue<Build>>(Process(builds));

    Type IPipeline.OutType => typeof(TOut);
}
