using System.Collections;
using System.Diagnostics;

using Arinc424.Linking;

namespace Arinc424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

    [Obsolete("TODO diagnostic log")]
    private void ProcessPrimaryKeys()
    {
        var types = Meta424.LinkingInfos.Where(x => x.Value.PrimaryRanges.Count != 0);

        foreach (var (type, info) in types)
        {
            unique[type] = [];

            foreach (var record in records[type])
            {
                string key = string.Empty;

                foreach (var range in info.PrimaryRanges)
                    key += record.Source[range].Replace(" ", null); // potentially need faster (unsafe?) way

                if (!unique[type].TryAdd(key, record))
                {
                    Debug.WriteLine($"{type} entity with key '{key}' already exist"); // TODO: logging path
                }
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void ProcessForeignKeys(Type type, Record424 record, LinkingInfo info)
    {
        foreach (var link in info.Links)
        {
            if (!link.TryGetKeyType(record.Source, out string? key, out var linkType))
                continue;

            if (this.unique.TryGetValue(linkType, out var unique))
            {
                if (unique.TryGetValue(key!, out var referenced))
                {
                    link.Property.SetValue(record, referenced);

                    if (Meta424.LinkingInfos[linkType].Many.TryGetValue(type, out var property))
                        _ = ((IList)property.GetValue(referenced)!).Add(record);
                }
                else
                {
                    Debug.WriteLine($"{linkType} entity with key '{key}' not found"); // TODO: logging path
                }
            }
            else
            {
                Debug.WriteLine($"{linkType} entity with key '{key}' is not valid for relationship"); // TODO: logging path
            }
        }
    }

    [Obsolete("TODO diagnostic log")]
    private void Link()
    {
        ProcessPrimaryKeys();

        foreach (var (type, info) in Meta424.LinkingInfos)
        {
            foreach (var record in records[type])
                ProcessForeignKeys(type, record, info);
        }
    }
}
