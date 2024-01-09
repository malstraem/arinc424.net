using System.Reflection;

using Arinc.Spec424.Attributes;
using Arinc.Spec424.Terms;

namespace Arinc.Spec424.Records;

internal static class RecordExtensions
{
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

        return recipients;
    }
}
