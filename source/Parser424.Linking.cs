using System.Collections;

using Arinc.Spec424.Linking;

namespace Arinc.Spec424;

internal partial class Parser424
{
    private readonly Dictionary<Type, Dictionary<string, Record424>> unique = [];

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
                    key += record.Source[range].Trim();

                unique[type].Add(key, record);
            }
        }
    }

    [Obsolete("TODO logging")]
    private void ProcessForeignKeys(Type type, Record424 record, LinkingInfo info)
    {
        foreach (var link in info.Links)
        {
            if (!link.TryGetType(record.Source, out var linkType))
                continue;

            if (!link.TryGetKey(linkType, record.Source, out string key))
                continue;

            if (unique[linkType].TryGetValue(key, out var referenced))
            {
                link.Property.SetValue(record, referenced);

                if (Meta424.LinkingInfos[linkType].Many.TryGetValue(type, out var property))
                    _ = ((IList)property.GetValue(referenced)!).Add(record);
            }
            else
            {
                Console.WriteLine("oops"); // TODO: logging path
            }
        }
    }

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
