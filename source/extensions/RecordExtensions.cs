using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

internal static class RecordExtensions
{
    [Obsolete("TODO rewrite")]
    internal static IReadOnlyCollection<TRecipient> Link<TRecipient, TLinked>(this IReadOnlyCollection<TRecipient> recipients, IEnumerable<TLinked> records)
        where TRecipient : Record424, IIdentifiable
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
}
