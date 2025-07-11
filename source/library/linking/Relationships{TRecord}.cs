using System.Collections.Frozen;
using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;
using Building;

internal abstract class Relationships(Type type)
{
#pragma warning disable CS8618
    protected FrozenDictionary<Type, PropertyInfo> many;
#pragma warning restore CS8618
    internal abstract void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta);

    internal static Relationships? Create(Type type, Supplement supplement)
        => (Relationships)typeof(Relationships<>)
            .MakeGenericType(type)!
                .GetMethod(nameof(Create), BindingFlags.NonPublic | BindingFlags.Static, [typeof(Supplement)])!
                    .Invoke(null, [supplement])!;

    internal Type Type { get; } = type;
}

internal sealed class Relationships<TRecord>(Link<TRecord>[] links) : Relationships(typeof(TRecord)) where TRecord : Record424
{
    private readonly Link<TRecord>[] links = links;

    private void Link(TRecord record, Unique unique, Queue<Diagnostic> diagnostics)
    {
        foreach (var link in links)
        {
            if (!link.TryLink(record, unique, out var diagnostic))
                diagnostics.Enqueue(diagnostic);
        }
    }

    internal override void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta)
    {
        Queue<Diagnostic> diagnostics = [];

        foreach (var build in (IEnumerable<Build<TRecord>>)builds) /* guarantee by design */
        {
            Link(build.Record, unique, diagnostics);

            if (diagnostics.Count != 0)
            {
                build.Diagnostics ??= [];
                build.Diagnostics.Pump(diagnostics);
            }
        }
    }

    internal static Relationships? Create(Supplement supplement)
    {
        var type = typeof(TRecord);

        var port = type.GetCustomAttribute<PortAttribute>();
        var icao = type.GetCustomAttribute<IcaoAttribute>();

        List<Link<TRecord>> links = [];

        Dictionary<Type, PropertyInfo> many = [];

        foreach (var property in type.GetProperties())
        {
            if (property.PropertyType == typeof(Ground.Port))
            {
                links.Add(port!.GetLink<TRecord>(property, icao!, supplement));
                continue;
            }

            var identifier = property.GetCustomAttributes<KnownAttribute>().BySupplement(supplement);

            if (identifier is not null)
            {
                links.Add(identifier.GetLink<TRecord>(property, icao, port, supplement));
            }
            else if (property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                many[property.PropertyType.GetElementType()!] = property;
            }
        }
        return links.Count == 0 && many.Count == 0 ? null : new Relationships<TRecord>([.. links])
        {
            many = many.ToFrozenDictionary()
        };
    }
}
