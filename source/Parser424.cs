using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Building;
using Arinc.Spec424.Records;
using Arinc.Spec424.Terms;
using Arinc.Spec424.Terms.Subsequences;

namespace Arinc.Spec424;

internal class Parser424
{
    private readonly Queue<string> skippedStrings = [];

    private readonly Dictionary<Type, Queue<string>> recordStrings = [];
    private readonly Dictionary<Type, Queue<string>> sequencedRecordStrings = [];

    internal Parser424()
    {
        foreach (var (type, info) in Meta424.RecordInfo)
            (info is SequencedRecordInfo ? sequencedRecordStrings : recordStrings).Add(type, []);
    }

    /// <summary>
    /// Checks that one of info matches the string and enqueue the matched to an associated queue.
    /// </summary>
    /// <param name="strings">Strings to check.</param>
    private void ProcessStrings(IEnumerable<string> strings)
    {
        foreach (string @string in strings)
        {
            if (!TryEnqueue(@string))
                skippedStrings.Enqueue(@string);
        }
    }

    private bool TryEnqueue(string @string)
    {
        foreach (var (type, info) in Meta424.RecordInfo)
        {
            if (info.IsMatch(@string))
            {
                (info is SequencedRecordInfo ? sequencedRecordStrings[type] : recordStrings[type]).Enqueue(@string);
                return true;
            }
        }
        return false;
    }

    /// <summary>
    /// Constructs <see cref="Record424"/> objects type of <typeparamref name="TRecord"/>.
    /// </summary>
    /// <typeparam name="TRecord">Target type of records.</typeparam>
    /// <returns>Constructed records or empty.</returns>
    private Queue<TRecord> Construct<TRecord>() where TRecord : Record424
    {
        Queue<TRecord> records = [];

        while (recordStrings[typeof(TRecord)].TryDequeue(out string? @string))
            records.Enqueue(RecordBuilder<TRecord>.Build(@string));

        return records;
    }

    /// <summary>
    /// Constructs <see cref="SequencedRecord424{TSequence}"/> type of <typeparamref name="TSequencedRecord"/> with sequence type of <typeparamref name="TSubsequence"/>.
    /// </summary>
    /// <typeparam name="TSequencedRecord">Target type of records.</typeparam>
    /// <typeparam name="TSubsequence">Target sequence type.</typeparam>
    /// <returns>Constructed records or empty.</returns>
    private Queue<TSequencedRecord> Construct<TSequencedRecord, TSubsequence>() where TSequencedRecord : SequencedRecord424<TSubsequence>
                                                                                where TSubsequence : Record424
    {
        var info = (SequencedRecordInfo)Meta424.RecordInfo[typeof(TSequencedRecord)];

        Queue<string> sequence = [];
        Queue<TSequencedRecord> records = [];

        int number;

        if (!sequencedRecordStrings[typeof(TSequencedRecord)].TryPeek(out string? @string))
            return records;

        number = int.Parse(@string[info.SequenceNumberRange]);

        while (sequencedRecordStrings[typeof(TSequencedRecord)].TryDequeue(out @string))
        {
            int next = int.Parse(@string[info.SequenceNumberRange]);

            if (next < number)
                records.Enqueue(RecordBuilder<TSequencedRecord, TSubsequence>.Build(sequence));

            number = next;

            sequence.Enqueue(@string);
        }

        records.Enqueue(RecordBuilder<TSequencedRecord, TSubsequence>.Build(sequence));

        return records;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="TLinked"></typeparam>
    /// <typeparam name="TRecipient"></typeparam>
    /// <param name="records"></param>
    /// <param name="recipients"></param>
    /// <exception cref="InvalidOperationException"></exception>
    /// <exception cref="Exception"></exception>
    private void Link<TRecipient, TLinked>(IEnumerable<TRecipient> recipients, IEnumerable<TLinked> records) where TRecipient : Record424, IIdentifiable
                                                                                                             where TLinked : Record424
    {
        var link = typeof(TLinked).GetProperties().SelectMany(property => property.GetCustomAttributes<LinkAttribute<TLinked, TRecipient>>()).FirstOrDefault();
        var receive = typeof(TRecipient).GetProperties().SelectMany(property => property.GetCustomAttributes<ReceiveAttribute<TRecipient, TLinked>>()).FirstOrDefault();

        if (link is null || receive is null)
            throw new Exception("oops");

        Dictionary<string, List<TLinked>> linkedRecords = [];

        foreach (var recipient in recipients)
            linkedRecords.Add(recipient.Identifier, []);

        foreach (var record in records)
        {
            if (linkedRecords.TryGetValue((string)link.Property.GetValue(record), out var targetRecords))
            {
                targetRecords.Add(record);
            }
            else
            {
                throw new InvalidOperationException();
            }
        }

        foreach (var recipient in recipients)
            receive.Property.SetValue(recipient, linkedRecords[recipient.Identifier]);
    }

    internal ArincData424 Parse(IEnumerable<string> strings)
    {
        ProcessStrings(strings);

        var runways = Construct<Runway>();
        var airports = Construct<Airport>();

        var airways = Construct<Airway>();
        var waypoints = Construct<Waypoint>();
        var cruisingTables = Construct<CruisingTable>();
        var holdingPatterns = Construct<HoldingPattern>();
        var flightPlannings = Construct<FlightPlanning>();
        var navigationalAids = Construct<NavigationalAid>();
        var airportApproaches = Construct<AirportApproach>();
        var nonDirectionalBeacons = Construct<NonDirectionalBeacon>();
        var microwaveLandingSystems = Construct<MicrowaveLandingSystem>();
        var standardTerminalArrivals = Construct<StandardTerminalArrival>();
        var standardInstrumentDepartures = Construct<StandardInstrumentDeparture>();

        var flightInfoRegions = Construct<FlightInfoRegion, BoundaryPoint>();
        var controlledAirspaces = Construct<ControlledAirspace, BoundaryPoint>();
        var restrictiveAirspaces = Construct<RestrictiveAirspace, BoundaryPoint>();

        Link(airports, runways);
        Link(airports, airportApproaches);
        Link(airports, standardTerminalArrivals);
        Link(airports, standardInstrumentDepartures);

        return new ArincData424
        {
            Runways = runways,
            Airways = airways,
            Airports = airports,
            Waypoints = waypoints,
            CruisingTables = cruisingTables,
            HoldingPatterns = holdingPatterns,
            FlightPlannings = flightPlannings,
            NavigationalAids = navigationalAids,
            AirportApproaches = airportApproaches,
            NonDirectionalBeacons = nonDirectionalBeacons,
            MicrowaveLandingSystems = microwaveLandingSystems,
            StandardTerminalArrivals = standardTerminalArrivals,
            StandardInstrumentDepartures = standardInstrumentDepartures,

            FlightInfoRegions = flightInfoRegions,
            ControlledAirspaces = controlledAirspaces,
            RestrictiveAirspaces = restrictiveAirspaces
        };
    }
}
