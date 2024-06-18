using System.Collections;

using Arinc424.Building;
using Arinc424.Diagnostics;
using Arinc424.Linking;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    private void ProcessPrimaryKey(Build build, Type type, PrimaryKey primaryKey)
    {
        var record = build.Record;

        string key = primaryKey.GetKey(record.Source);

        if (!unique[type].TryAdd(key, record))
        {
            build.Diagnostics ??= [];
            build.Diagnostics.Enqueue(new DuplicateDiagnostic(record, type, key));
            Debug.WriteLine(build.Diagnostics.Last());
        }
    }

    [Obsolete("todo: diagnostic log")]
    private void ProcessForeignKeys(Record424 record, LinksAttribute info)
    {
        foreach (var link in info.Links!)
        {
            if (!link.TryGetReference(record.Source!, meta, out var reference))
                continue;

            if (!this.unique.TryGetValue(reference!.Type, out var unique))
            {
                // todo: diagnostic log
                Debug.WriteLine($"Entity type '{reference.Type} not found in unique types"); // TODO: logging path
                continue;
            }

            if (!unique.TryGetValue(reference.Key, out var referenced))
            {
                // todo: diagnostic log
                Debug.WriteLine($"{reference.Type} entity with key '{reference.Key}' not found"); // TODO: logging path
                continue;
            }

            try
            {
                reference.Property.SetValue(record, referenced);

                var one = meta.Links[reference.Type].One;
                var many = meta.Links[reference.Type].Many;

                if (many is not null && many.TryGetValue(info.Type, out var property))
                {
                    if (property.GetValue(referenced) is null)
                        property.SetValue(referenced, Activator.CreateInstance(typeof(List<>).MakeGenericType(info.Type)));

                    _ = ((IList)property.GetValue(referenced)!).Add(record);
                }
                else if (one is not null && one.TryGetValue(info.Type, out property))
                {
                    property.SetValue(referenced, record);
                }
            }
            catch (Exception ex)
            {
                // todo: diagnostic log
                Debug.WriteLine(ex);
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void Link()
    {
        var attributes = meta.GetWithPrimaryKey();

        foreach (var attribute in attributes)
            unique[attribute.Type] = [];

        _ = Parallel.ForEach(attributes, x =>
        {
            foreach (var build in builds[x.Type])
                ProcessPrimaryKey(build, x.Type, x.PrimaryKey!);
        });

        _ = Parallel.ForEach(meta.GetWithLinks(), x =>
        {
            foreach (var build in builds[x.Type])
                ProcessForeignKeys(build.Record, x);
        });

        // todo
        _ = Parallel.ForEach(meta.Sequences.Where(x => x.SubLinks.Links is not null), x =>
        {
            foreach (var record in builds[x.Type])
            {
                foreach (var sub in x.GetSequence(record.Record))
                    ProcessForeignKeys(sub, x.SubLinks);
            }
        });
    }
}
