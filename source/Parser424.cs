using System.Collections;
using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Building;
using Arinc.Spec424.Linking;
using Arinc.Spec424.Records;
using Arinc.Spec424.Records.Subsequences;

namespace Arinc.Spec424;

internal class Parser424
{
    private readonly Queue<string> skipped = [];

    private readonly Dictionary<Type, Queue<string>> strings = [];

    private readonly Dictionary<Type, Queue<(Record424, (IReadOnlyList<Link>, Link?))>> records = [];

    private readonly Dictionary<Type, Dictionary<string, Record424>> identities = [];

    internal Parser424()
    {
        foreach (var (type, _) in Meta424.RecordInfos)
            strings[type] = [];

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

        // Checks that one of info matches the string and enqueue the matched to an associated queue.
        // TODO use branching?
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

    /// <summary>
    /// Constructs <see cref="Record424"/> objects type of <typeparamref name="TRecord"/>.
    /// </summary>
    /// <typeparam name="TRecord">Target type of records.</typeparam>
    private void Construct<TRecord>() where TRecord : Record424, new()
    {
        var type = typeof(TRecord);

        var info = Meta424.LinkingInfos[type];

        while (strings[type].TryDequeue(out string? @string))
            records[type].Enqueue((RecordBuilder<TRecord>.Build(@string), info.GetLinks(@string)));
    }

    /// <summary>
    /// Constructs <see cref="SequencedRecord424{TSubsequence}"/> type of <typeparamref name="TSequencedRecord"/> with subsequence type of <typeparamref name="TSubsequence"/>.
    /// </summary>
    /// <typeparam name="TSequencedRecord">Target type of records.</typeparam>
    /// <typeparam name="TSubsequence">Target sequence type.</typeparam>
    /// <returns>Constructed records or empty.</returns>
    private void Construct<TSequencedRecord, TSubsequence>() where TSequencedRecord : SequencedRecord424<TSubsequence>, new()
                                                             where TSubsequence : Record424, new()
    {
        var type = typeof(TSequencedRecord);
        var subType = typeof(TSubsequence);

        if (!strings[type].TryPeek(out string? @string))
            return;

        var info = Meta424.LinkingInfos[type];
        var subInfo = Meta424.LinkingInfos[subType];

        var sequenceRange = ((SequencedRecordInfo)Meta424.RecordInfos[type]).SequenceNumberRange;

        int number = int.Parse(@string[sequenceRange]);

        Queue<string> sequence = [];

        while (strings[type].TryDequeue(out @string))
        {
            int next = int.Parse(@string[sequenceRange]);

            if (next < number)
                ConstructSequenced(sequence);

            number = next;

            sequence.Enqueue(@string);
        }
        ConstructSequenced(sequence);

        void ConstructSequenced(Queue<string> sequence)
        {
            var sequencedRecord = RecordBuilder<TSequencedRecord, TSubsequence>.Build(sequence);

            records[type].Enqueue((sequencedRecord, info.GetLinks(sequence.First())));

            int i = 0;

            while (sequence.TryDequeue(out string? @substring))
                records[subType].Enqueue((sequencedRecord.Subsequences[i], subInfo.GetLinks(@substring)));
        }
    }

    [Obsolete("TODO multithreading")]
    private void Construct()
    {
        Construct<Runway>();
        Construct<Airport>();
        Construct<Waypoint>();
        Construct<CruisingTable>();
        Construct<HoldingPattern>();
        Construct<FlightPlanning>();
        Construct<OmnidirectionalStation>();
        Construct<NonDirectionalBeacon>();
        Construct<MicrowaveLandingSystem>();

        Construct<Airway, AirwayPoint>();
        Construct<Approach, ProcedurePoint>();
        Construct<StandardTerminalArrival, ProcedurePoint>();
        Construct<StandardInstrumentDeparture, ProcedurePoint>();

        Construct<FlightInfoRegion, BoundaryPoint>();
        Construct<ControlledAirspace, BoundaryPoint>();
        Construct<RestrictiveAirspace, BoundaryPoint>();

        /*Task.WaitAll
        (
            Task.Run(Construct<Runway>),
            Task.Run(Construct<Airport>),
            Task.Run(Construct<Waypoint>),
            Task.Run(Construct<CruisingTable>),
            Task.Run(Construct<HoldingPattern>),
            Task.Run(Construct<FlightPlanning>),
            Task.Run(Construct<OmnidirectionalStation>),
            Task.Run(Construct<NonDirectionalBeacon>),
            Task.Run(Construct<MicrowaveLandingSystem>),

            Task.Run(Construct<Airway, AirwayPoint>),
            Task.Run(Construct<AirportApproach, ProcedurePoint>),
            Task.Run(Construct<StandardTerminalArrival, ProcedurePoint>),
            Task.Run(Construct<StandardInstrumentDeparture, ProcedurePoint>),

            Task.Run(Construct<FlightInfoRegion, BoundaryPoint>),
            Task.Run(Construct<ControlledAirspace, BoundaryPoint>),
            Task.Run(Construct<RestrictiveAirspace, BoundaryPoint>)
        );*/
    }

    private void Link()
    {
        // hard coded test of airport linking
        var properties = typeof(Airport).GetProperties().Where(p => p.GetCustomAttribute<ManyAttribute>() is not null);

        var airportType = typeof(Airport);
        var airports = identities[airportType] = [];

        foreach (var (record, _) in records[airportType])
        {
            var airport = (Airport)record;
            airports.Add(airport.Identifier + airport.IcaoCode, airport);
        }

        foreach (var property in properties)
        {
            var type = property.PropertyType.GetGenericArguments().First();

            foreach (var (record, (_, airportLink)) in records[type])
            {
                /*if (airportLink is null)
                    continue;*/

                if (airports.TryGetValue(airportLink.Key, out var airport))
                {
                    airportLink.Info.Property.SetValue(record, airport);

                    var list = (IList)property.GetValue(airport);

                    list.Add(record);
                }
            }
        }
    }

    internal Data424 Parse(IEnumerable<string> strings)
    {
        Process(strings);
        Construct();
        Link();

        return new Data424();
    }
}
