using System.Collections;
using System.Diagnostics;

using Arinc424.Attributes;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("TODO diagnostic log")]
    private void ProcessPrimaryKey(Record424 record, InfoAttribute info)
    {
        string key = info.PrimaryKey!.GetKey(record.Source);

        if (!unique[info.Type].TryAdd(key, record))
        {
            Debug.WriteLine($"{info.Type} entity with key '{key}' already exist"); // TODO: logging path
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void ProcessForeignKeys(Record424 record, RelationsAttribute relations)
    {
        foreach (var link in relations.Links!)
        {
            if (!link.TryGetReference(record.Source, out var reference))
                continue;

            if (!this.unique.TryGetValue(reference!.Type, out var unique))
            {
                Debug.WriteLine($"Entity type '{reference.Type} not found in unique types"); // TODO: logging path
                continue;
            }

            if (!unique.TryGetValue(reference.Key, out var referenced))
            {
                Debug.WriteLine($"{reference.Type} entity with key '{reference.Key}' not found"); // TODO: logging path
                continue;
            }

            try
            {
                reference.Property.SetValue(record, referenced);

                var one = Meta424.Infos[reference.Type].One;
                var many = Meta424.Infos[reference.Type].Many;

                if (many is not null && many.TryGetValue(relations.Type, out var property))
                {
                    if (property.GetValue(referenced) is null)
                        property.SetValue(referenced, Activator.CreateInstance(typeof(List<>).MakeGenericType(relations.Type)));

                    _ = ((IList)property.GetValue(referenced)!).Add(record);
                }
                else if (one is not null && one.TryGetValue(relations.Type, out property))
                {
                    property.SetValue(referenced, record);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex); // TODO: logging path
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void Link()
    {
        var infos = Meta424.Infos.Where(x => x.Value.PrimaryKey is not null);

        foreach (var (type, _) in infos)
            unique[type] = [];

        _ = Parallel.ForEach(infos, x =>
        {
            foreach (var record in records[x.Key])
                ProcessPrimaryKey(record, x.Value);
        });

        _ = Parallel.ForEach(Meta424.Infos.Where(x => x.Value.Links is not null), x =>
        {
            foreach (var record in records[x.Key])
                ProcessForeignKeys(record, x.Value);
        });

        _ = Parallel.ForEach(Meta424.Sequences.Where(x => x.SubInfo.Links is not null), x =>
        {
            foreach (var record in records[x.Type])
            {
                foreach (var sub in x.GetSequence(record))
                    ProcessForeignKeys(sub, x.SubInfo);
            }
        });
    }
}
