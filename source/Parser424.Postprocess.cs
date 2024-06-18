using Arinc424.Building;
using Arinc424.Procedures;

namespace Arinc424;

internal partial class Parser424
{
    private void ConcatProcedureSequences<TProcedure, TSequence, TSub>()
        where TProcedure : Procedure<TSequence, TSub>, new()
        where TSequence : ProcedureSequence<TSub>
        where TSub : ProcedurePoint
    {
        Queue<Build> procedures = [];
        Queue<TSequence> sequences = [];

        var builds = this.builds[typeof(TSequence)];

        while (builds.TryDequeue(out var build))
        {
            var sequence = (TSequence)build.Record;
            sequences.Enqueue(sequence);

            if (!builds.TryPeek(out build) || ((TSequence)build.Record).Identifier != sequence.Identifier)
            {
                procedures.Enqueue(new Build(new TProcedure
                {
                    Source = sequence.Source,
                    AreaCode = sequence.AreaCode,
                    IcaoCode = sequence.IcaoCode,
                    Identifier = sequence.Identifier,
                    Sequences = [.. sequences],
                }, null)); // todo: save diagnostics
                sequences.Clear();
            }
        }
        this.builds[typeof(TProcedure)] = procedures;
    }

    [Obsolete("placeholder")]
    private void Postprocess()
    {
        ConcatProcedureSequences<AirportArrival, AirportArrivalSequence, ArrivalPoint>();
        ConcatProcedureSequences<AirportApproach, AirportApproachSequence, ApproachPoint>();
        ConcatProcedureSequences<AirportDeparture, AirportDepartureSequence, DeparturePoint>();
    }
}
