using Arinc424.Building;
using Arinc424.Procedures;

namespace Arinc424.Processing;

internal abstract class ProcedureConcatenater<TProcedure, TSequence, TSub> : IProcessor<TProcedure, TSequence>
    where TProcedure : Procedure<TSequence, TSub>, new()
    where TSequence : ProcedureSequence<TSub>, new()
    where TSub : ProcedurePoint, new()
{
    private static TProcedure New(TSequence sub) => new()
    {
        Source = sub.Source,
        AreaCode = sub.AreaCode,
        IcaoCode = sub.IcaoCode,
        Identifier = sub.Identifier,
    };

    private static bool Trigger(TSequence one, TSequence other) => one.Identifier != other.Identifier;

    public static IEnumerable<Build<TProcedure>> Process(Queue<Build<TSequence>> records)
        => Concatenater<TProcedure, TSequence>.Concat(records, New, Trigger);
}
