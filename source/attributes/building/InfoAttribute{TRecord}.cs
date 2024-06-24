using System.Collections;
using System.Reflection;

using Arinc424.Building;
using Arinc424.Linking;

namespace Arinc424.Attributes;

#pragma warning disable CS8618
internal abstract class InfoAttribute() : Attribute
#pragma warning restore CS8618
{
    protected Type type;

    protected LinksInfo links;

    protected PrimaryKey? primaryKey;

    protected SectionAttribute section;

    protected int? continuationIndex;

    internal bool IsMatch(string @string) => section.IsMatch(@string);

    internal bool IsContinuation(string @string) => continuationIndex is not null && @string[continuationIndex.Value] is not '0' and not '1';

    internal abstract IEnumerable<Build> Build(Queue<string> strings);

    [Obsolete("todo: diagnostic log")]
    internal void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta)
    {
        if (links.Links is not null)
        {
            foreach (var build in builds)
            {
                var record = build.Record;

                foreach (var link in links.Links)
                {
                    if (!link.TryGetReference(record.Source!, meta, out var reference))
                        continue;

                    if (!unique.unique.TryGetValue(reference!.Type, out var uniqueTypes))
                    {
                        // todo: diagnostic log
                        Debug.WriteLine($"Entity type '{reference.Type} not found in unique types"); // TODO: logging path
                        continue;
                    }

                    if (!uniqueTypes.TryGetValue(reference.Key, out var referenced))
                    {
                        // todo: diagnostic log
                        Debug.WriteLine($"{reference.Type} entity with key '{reference.Key}' not found"); // TODO: logging path
                        continue;
                    }

                    try
                    {
                        reference.Property.SetValue(record, referenced);

                        var one = meta.TypeInfo[reference.Type].links.One;
                        var many = meta.TypeInfo[reference.Type].links.Many;

                        if (many is not null && many.TryGetValue(type, out var property))
                        {
                            object? value = property.GetValue(referenced);

                            if (value is null)
                                property.SetValue(referenced, value = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)));

                            _ = ((IList)value!).Add(record);
                        }
                        else if (one is not null && one.TryGetValue(type, out property))
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
        }
    }

    internal Type Type => type;

    internal PrimaryKey? PrimaryKey => primaryKey;

    internal (char, char) Section => (section.Section, section.Subsection);
}

internal abstract class InfoAttribute<TRecord> : InfoAttribute where TRecord : Record424, new()
{
    protected readonly BuildInfo<TRecord> info = new();

    protected readonly ProcessAttribute<TRecord>? process;

    internal InfoAttribute()
    {
        var type = typeof(TRecord);

        section = type.GetCustomAttribute<SectionAttribute>()!;
        process = type.GetCustomAttribute<ProcessAttribute<TRecord>>();
        continuationIndex = type.GetCustomAttribute<ContinuousAttribute>()?.Index;

        this.type = process is null ? typeof(TRecord) : process.NewType;

        links = new(this.type);

        primaryKey = PrimaryKey.Create(this.type.GetProperties());
    }
}
