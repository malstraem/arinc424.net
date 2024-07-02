using System.Collections;
using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Relations(Type type)
{
    protected readonly Type type = type;

    protected internal readonly Dictionary<Type, PropertyInfo> one = [];

    protected internal readonly Dictionary<Type, PropertyInfo> many = [];

    protected internal abstract void Link(Record424 record, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics);

    internal abstract void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta);
}

internal class Relations<TRecord> : Relations where TRecord : Record424
{
    private readonly Link<TRecord>[] links;

    private readonly (Relations Relations, PropertyInfo Property)? inner;

    [Obsolete("todo: linking just works, but so dirty and not guarantee")]
    private void ProcessLinks(Record424 record, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics)
    {
        foreach (var link in links)
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

                var one = meta.TypeInfo[reference.Type].Relations.one;
                var many = meta.TypeInfo[reference.Type].Relations.many;

                if (many.TryGetValue(type, out var property))
                {
                    object? value = property.GetValue(referenced);

                    if (value is null)
                        property.SetValue(referenced, value = Activator.CreateInstance(typeof(List<>).MakeGenericType(type)));

                    _ = ((IList)value!).Add(record);
                }
                else if (one.TryGetValue(type, out property))
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

    protected internal override void Link(Record424 record, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics)
    {
        ProcessLinks(record, unique, meta, diagnostics);

        if (inner is null)
            return;

        var (relations, property) = inner.Value;

        var subs = (IEnumerable<Record424>)property.GetValue(record)!;

        foreach (var sub in subs)
            relations.Link(sub, unique, meta, diagnostics);
    }

    public Relations() : base(typeof(TRecord))
    {
        List<Link<TRecord>> links = [];

        foreach (var property in type.GetProperties())
        {
            var linkAttribute = property.GetCustomAttribute<IdentifierAttribute>();

            if (linkAttribute is not null)
            {
                var linkType = typeof(Link<,>).MakeGenericType(typeof(TRecord), property.PropertyType);

                var icao = property.GetCustomAttribute<IcaoAttribute>()?.Range;
                var port = property.GetCustomAttribute<PortAttribute>()?.Range;

                object link = Activator.CreateInstance(linkType, linkAttribute.Range, icao, port, property, property.GetCustomAttribute<TypeAttribute>())!;

                links.Add((Link<TRecord>)link);
            }
            else if (property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                many.Add(property.PropertyType.GetGenericArguments().First(), property);
            }
            else if (property.GetCustomAttribute<OneAttribute>() is not null)
            {
                one.Add(property.PropertyType, property);
            }
            else if (property.Name == nameof(Record424<Record424>.Sequence))
            {
                var innerRelationsType = typeof(Relations<>).MakeGenericType(property.PropertyType.GetElementType()!);

                inner = ((Relations)Activator.CreateInstance(innerRelationsType)!, property);
            }
        }
        this.links = [.. links];
    }

    internal override void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta)
    {
        foreach (var build in builds)
            Link(build.Record, unique, meta, null);
    }
}
