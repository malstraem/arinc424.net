using Arinc424.Building;
using Arinc424.Procedures;

namespace Arinc424;

internal partial class Parser424
{
    private void Concat<TSequence, TSub>(Func<TSub, TSequence> @new, Func<TSub, TSub, bool> trigger)
        where TSequence : Record424<TSub>
        where TSub : Record424
    {
        var builds = this.builds[typeof(TSub)];

        var enumerator = builds.GetEnumerator();

        Queue<TSub> sequence = [];
        Queue<Build> procedures = [];

        TSub sub, next;

        if (enumerator.MoveNext())
        {
            sequence.Enqueue(sub = (TSub)enumerator.Current.Record);

            while (enumerator.MoveNext())
            {
                next = (TSub)enumerator.Current.Record;

                if (trigger(next, sub))
                {
                    Enqueue();
                    sequence.Clear();
                }
                sequence.Enqueue(sub = next);
            }
            Enqueue();

            void Enqueue()
            {
                var result = @new(sub);
                result.Sequence = [.. sequence];

                procedures.Enqueue(new Build<TSequence, TSub>(result)); // todo: save diagnostics
                sequence.Clear();
            }
        }
        this.builds[typeof(TSequence)] = procedures;
    }

    private void Postprocess()
    {
        static AirportArrival @new(AirportArrivalSequence sub) => new()
        {
            Source = sub.Source,
            AreaCode = sub.AreaCode,
            IcaoCode = sub.IcaoCode,
            Identifier = sub.Identifier,
        };

        static bool trigger(AirportArrivalSequence one, AirportArrivalSequence other) => one.Identifier != other.Identifier;

        Concat<AirportArrival, AirportArrivalSequence>(@new, trigger);
        //Concat<AirportApproach, AirportApproachSequence>();
        //Concat<AirportDeparture, AirportDepartureSequence>();
    }
}
