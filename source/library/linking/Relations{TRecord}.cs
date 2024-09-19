using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Relations(Type type)
{
    protected readonly Type type = type;

    protected internal readonly Dictionary<Type, PropertyInfo> one = [];
    protected internal readonly Dictionary<Type, PropertyInfo> many = [];

    protected internal abstract void Link(IEnumerable<Record424> records, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics);

    internal abstract void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta);

    internal void Process<TRecord>(Type type, Record424 self, TRecord referenced) where TRecord : Record424
    {
        // todo: compiled one & many relations
        if (many.TryGetValue(type, out var property))
        {
            if (property.GetValue(self) is not List<TRecord> value)
                property.SetValue(self, value = []);

            value.Add(referenced);
        }
        else if (one.TryGetValue(type, out property))
        {
            property.SetValue(referenced, referenced);
        }
    }
}

internal sealed class Relations<TRecord> : Relations where TRecord : Record424
{
    private readonly Link<TRecord>[] links;

    private readonly (Relations Relations, PropertyInfo Property)? inner;

    [Obsolete("todo: need polish")]
    private void Link(TRecord record, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics)
    {
        foreach (var link in links)
        {
            link.TryLink(record, unique, meta, out var diagnostic);
        }

        if (inner is null)
            return;

        var (relations, property) = inner.Value;

        relations.Link((IEnumerable<Record424>)property.GetValue(record)!, unique, meta, diagnostics);
    }

    protected internal override void Link(IEnumerable<Record424> records, Unique unique, Meta424 meta, Queue<Diagnostic>? diagnostics)
    {
        foreach (var record in (IEnumerable<TRecord>)records)
            Link(record, unique, meta, diagnostics);
    }

    internal override void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta)
        => Link(((IEnumerable<Build<TRecord>>)builds).Select(x => x.Record), unique, meta, null);

    public Relations(Supplement supplement) : base(typeof(TRecord))
    {
        List<Link<TRecord>> links = [];

        foreach (var property in type.GetProperties())
        {
            var identifier = property.GetCustomAttributes<IdentifierAttribute>().BySupplement(supplement);

            if (identifier is not null)
            {
                links.Add(identifier.GetLink<TRecord>(property, supplement));
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
                var innerRelationsType = typeof(Relations<>).MakeGenericType(property.PropertyType.GetGenericArguments().First()!);

                inner = ((Relations)Activator.CreateInstance(innerRelationsType, supplement)!, property);
            }
        }
        this.links = [.. links];
    }
}
