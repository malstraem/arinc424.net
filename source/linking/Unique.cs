using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

/// <summary>
/// Container with records that have unique keys.
/// </summary>
internal class Unique
{
    internal readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    private void ProcessPrimaryKey(Build build, Type type, PrimaryKey primaryKey)
    {
        var record = build.Record;

        string key = primaryKey.GetKey(record.Source);

        if (unique[type].TryAdd(key, record))
            return;

        build.Diagnostics ??= [];
        build.Diagnostics.Enqueue(new DuplicateDiagnostic(record, type, key));
        Debug.WriteLine(build.Diagnostics.Last());
    }

    internal Unique(IEnumerable<InfoAttribute> attributes, IDictionary<Type, IEnumerable<Build>> builds)
    {
        foreach (var attribute in attributes.Where(x => x.PrimaryKey is not null))
        {
            unique[attribute.Type] = [];

            foreach (var build in builds[attribute.Type])
                ProcessPrimaryKey(build, attribute.Type, attribute.PrimaryKey!);
        };
    }
}
