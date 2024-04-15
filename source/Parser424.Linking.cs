using System.Collections;
using System.Diagnostics;

using Arinc424.Attributes;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("TODO diagnostic log")]
    private void ProcessPrimaryKeys(InfoAttribute info)
    {
        var type = info.Type;

        unique[type] = [];

        foreach (var record in records[type])
        {
            string key = info.GetPrimaryKey(record);

            if (!unique[type].TryAdd(key, record))
            {
                Debug.WriteLine($"{type} entity with key '{key}' already exist"); // TODO: logging path
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void ProcessForeignKeys(InfoAttribute info)
    {
        var type = info.Type;

        foreach (var record in records[type])
        {
            foreach (var reference in info.GetReferences(record))
            {
                if (!this.unique.TryGetValue(reference.Type, out var unique))
                    Debug.WriteLine($"Entity type '{reference.Type} not found in unique types"); // TODO: logging path

                if (!unique!.TryGetValue(reference.Key, out var referenced))
                    Debug.WriteLine($"{reference.Type} entity with key '{reference.Key}' not found"); // TODO: logging path

                reference.Property.SetValue(record, referenced);

                var many = Meta424.Infos[reference.Type].Many;

                if (many.TryGetValue(type, out var property))
                    _ = ((IList)property.GetValue(referenced)!).Add(record);
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void Link()
    {
        foreach (var (_, info) in Meta424.Infos.Where(x => x.Value.HasKey))
            ProcessPrimaryKeys(info);

        foreach (var (_, info) in Meta424.Infos.Where(x => x.Value.HasLinks))
            ProcessForeignKeys(info);
    }
}
