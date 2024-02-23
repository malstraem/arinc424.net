using System.Collections;
using System.Collections.Concurrent;

using Arinc.Spec424.Building;
using Arinc.Spec424.Records;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424;

internal partial class Parser424
{
    private readonly Queue<string> skipped = [];

    private readonly Dictionary<Type, Queue<string>> strings = [];
    private readonly Dictionary<Type, Queue<string>> primary = [];
    private readonly Dictionary<Type, Queue<string>> continuation = [];

    private readonly Dictionary<Type, ConcurrentQueue<(Record424 Record, string Source)>> records = [];

    internal Parser424()
    {
        foreach (var (type, _) in Meta424.RecordInfos)
        {
            strings[type] = [];
            primary[type] = [];
            continuation[type] = [];
        }

        foreach (var type in Meta424.RecordTypes)
            records[type] = [];
    }

    private void Process(IEnumerable<string> strings)
    {
        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skipped.Enqueue(@string);
        }

        SplitStrings();

        // Checks that one of info matches the string and enqueue the matched to an associated queue.
        // (branching, apparently, will not give any tangible gain)
        bool TryEnqueue(string @string)
        {
            foreach (var (type, strings) in this.strings)
            {
                if (!Meta424.RecordInfos[type].IsMatch(@string))
                    continue;

                strings.Enqueue(@string);
                return true;
            }
            return false;
        }
    }

    private void SplitStrings()
    {
        foreach (var (type, info) in Meta424.RecordInfos)
        {
            if (info.continuationIndex is null)
            {
                while (strings[type].TryDequeue(out string? @string))
                    primary[type].Enqueue(@string);
            }
            else
            {
                int index = info.continuationIndex.Value;

                while (strings[type].TryDequeue(out string? @string))
                    (@string[index] is '0' or '1' ? primary[type] : continuation[type]).Enqueue(@string);
            }
        }
    }

    /// <summary>
    /// Constructs <see cref="Record424"/> objects type of <typeparamref name="TRecord"/>.
    /// </summary>
    /// <typeparam name="TRecord">Target type of records.</typeparam>
    private void Construct<TRecord>() where TRecord : Record424, new()
    {
        var type = typeof(TRecord);

        while (primary[type].TryDequeue(out string? @string))
            records[type].Enqueue((RecordBuilder<TRecord>.Build(@string), @string));
    }

    /// <summary>
    /// Constructs <see cref="Record424{TSub}"/> type of <typeparamref name="TRecord"/> with sequence type of <typeparamref name="TSub"/>.
    /// </summary>
    /// <typeparam name="TRecord">Target type of records.</typeparam>
    /// <typeparam name="TSub">Target sequence type.</typeparam>
    /// <returns>Constructed records or empty.</returns>
    private void Construct<TRecord, TSub>() where TRecord : Record424<TSub>, new()
                                            where TSub : Record424, new()
    {
        var type = typeof(TRecord);
        var subType = typeof(TSub);

        if (!primary[type].TryDequeue(out string? @string))
            return;

        var sequenceRange = ((SequencedRecordInfo)Meta424.RecordInfos[type]).SequenceRange;

        Queue<string> sequence = [];

        int number = int.Parse(@string[sequenceRange]);

        do
        {
            int next = int.Parse(@string[sequenceRange]);

            if (next < number)
                ConstructSequenced(sequence);

            number = next;

            sequence.Enqueue(@string);
        }
        while (primary[type].TryDequeue(out @string));

        ConstructSequenced(sequence);

        void ConstructSequenced(Queue<string> sequence)
        {
            var sequencedRecord = RecordBuilder<TRecord, TSub>.Build(sequence);

            records[type].Enqueue((sequencedRecord, sequence.First()));

            int i = 0;

            while (sequence.TryDequeue(out string? @substring))
            {
                records[subType].Enqueue((sequencedRecord.Sequence[i], substring));
                i++;
            }
        }
    }

    private void Construct()
    {
        Parallel.Invoke
        (
            Construct<Runway>,
            Construct<Airport>,
            Construct<CruisingTable>,
            Construct<HoldingPattern>,
            Construct<FlightPlanning>,
            Construct<EnrouteWaypoint>,
            Construct<AirportTerminalWaypoint>,
            Construct<NonDirectionalBeacon>,
            Construct<OmnidirectionalStation>,
            Construct<MicrowaveLandingSystem>,

            Construct<Airway, AirwayPoint>,
            Construct<AirportApproach, ProcedurePoint>,
            Construct<AirportTerminalArrival, ProcedurePoint>,
            Construct<AirportInstrumentDeparture, ProcedurePoint>,

            Construct<FlightInfoRegion, BoundaryPoint>,
            Construct<ControlledAirspace, BoundaryPoint>,
            Construct<RestrictiveAirspace, BoundaryPoint>
        );
    }

    internal Data424 Parse(IEnumerable<string> strings)
    {
        Process(strings);
        Construct();
        Link();

        var data = new Data424();

        foreach (var property in typeof(Data424).GetProperties())
        {
            var type = property.PropertyType.GetGenericArguments().First();

            var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type))!;

            while (records[type].TryDequeue(out var item))
                _ = list.Add(item.Record);

            property.SetValue(data, list);
        }

        return data;
    }
}
