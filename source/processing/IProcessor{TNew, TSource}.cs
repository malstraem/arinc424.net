using Arinc424.Building;

namespace Arinc424.Processing;

internal interface IProcessor<TNew, TSource> where TNew : Record424, new() where TSource : Record424, new()
{
    public static abstract IEnumerable<Build<TNew>> Process(Queue<Build<TSource>> builds);
}
