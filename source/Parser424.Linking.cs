using System.Collections;
using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Records;

namespace Arinc.Spec424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> identities = [];

    private void Link()
    {
        LinkByAirport();
    }

    internal void LinkByAirport()
    {
        // hard coded test of airport linking

        var airportType = typeof(Airport);

        var properties = airportType.GetProperties().Where(p => p.GetCustomAttribute<ManyAttribute>() is not null);

        var airports = identities[airportType] = [];

        foreach (var (record, _) in records[airportType])
        {
            var airport = (Airport)record;
            airports.Add(airport.Identifier + airport.IcaoCode, airport);
        }

        foreach (var property in properties)
        {
            var type = property.PropertyType.GetGenericArguments().First();

            var info = Meta424.LinkingInfos[type];

            foreach (var (record, @string) in records[type])
            {
                var (links, airportLink) = info.GetLinks(@string);

                if (airportLink is not null && airports.TryGetValue(airportLink.Key, out var airport))
                {
                    airportLink.Info.Property.SetValue(record, airport);

                    _ = ((IList)property.GetValue(airport)!).Add(record);
                }
            }
        }
    }
}

/*internal static class RecordExtensions
{
    [Obsolete("TODO rewrite")]
    internal static IReadOnlyCollection<TRecipient> Link<TRecipient, TLinked>(this IReadOnlyCollection<TRecipient> recipients, IEnumerable<TLinked> records)
        where TRecipient : Record424, IIdentity
        where TLinked : Record424
    {
        var link = typeof(TLinked).GetProperties().SelectMany(property => property.GetCustomAttributes<LinkAttribute<TLinked, TRecipient>>()).FirstOrDefault();
        var receive = typeof(TRecipient).GetProperties().SelectMany(property => property.GetCustomAttributes<ManyAttribute<TRecipient, TLinked>>()).FirstOrDefault();

        if (link is null || receive is null)
            throw new Exception("oops");

        Dictionary<string, List<TLinked>> linkedRecords = [];

        foreach (var recipient in recipients)
            linkedRecords.Add(recipient.Identifier, []);

        foreach (var record in records)
        {
            object? value = link.Property.GetValue(record);

            if (value is null)
                continue;

            if (linkedRecords.TryGetValue((string)value, out var targetRecords))
                targetRecords.Add(record);
        }

        foreach (var recipient in recipients)
            receive.Property.SetValue(recipient, linkedRecords[recipient.Identifier]);

        return recipients;
    }
}*/
