using System.Collections;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("todo: diagnostic log")]
    private void ProcessPrimaryKey(Record424 record, InfoAttribute info)
    {
        string key = info.PrimaryKey!.GetKey(record.Source);

        if (!unique[info.Type].TryAdd(key, record))
        {
            // todo: diagnostic log
            Debug.WriteLine($"{info.Type} entity with key '{key}' already exist"); // TODO: logging path
        }
    }

    [Obsolete("todo: diagnostic log")]
    private void ProcessForeignKeys(Record424 record, BuildAttribute info)
    {
        foreach (var link in info.Links!)
        {
            if (!link.TryGetReference(record.Source, meta, out var reference))
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

                var one = meta.Info[reference.Type].One;
                var many = meta.Info[reference.Type].Many;

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
        var info = meta.Info.Where(x => x.Value.PrimaryKey is not null);

        foreach (var (type, _) in info)
            unique[type] = [];

        _ = Parallel.ForEach(info, x =>
        {
            foreach (var record in records[x.Key])
                ProcessPrimaryKey(record, x.Value);
        });

        _ = Parallel.ForEach(meta.Info.Where(x => x.Value.Links is not null), x =>
        {
            foreach (var record in records[x.Key])
                ProcessForeignKeys(record, x.Value);
        });

        _ = Parallel.ForEach(meta.Sequences.Where(x => x.SubInfo.Links is not null), x =>
        {
            foreach (var record in records[x.Type])
            {
                foreach (var sub in x.GetSequence(record))
                    ProcessForeignKeys(sub, x.SubInfo);
            }
        });
    }
}
