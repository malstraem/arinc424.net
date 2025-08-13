using System.Reflection;

namespace Arinc424.Linking;

using Diagnostics;

internal abstract class Relation(Type type)
{
#pragma warning disable CS8618
    protected Aggregation[] aggregations;
#pragma warning restore CS8618
    internal static Relation? Create(Type type, Supplement supplement)
    => (Relation)typeof(Relation<>)
        .MakeGenericType(type)!
            .GetMethod(nameof(Create), BindingFlags.NonPublic | BindingFlags.Static, [typeof(Supplement)])!
                .Invoke(null, [supplement])!;

    internal void Aggregate(Builds builds)
    {
        foreach (var aggregation in aggregations)
            aggregation.Aggregate(builds[Type], builds[aggregation.Type]);
    }

    internal abstract void Link(Queue<Build> builds, Unique unique, Meta424 meta);

    internal Type Type { get; } = type;

    internal abstract Link[] Links { get; }
}

internal sealed class Relation<TRecord>(Link<TRecord>[] links) : Relation(typeof(TRecord))
    where TRecord : Record424
{
    private readonly Link<TRecord>[] links = links;

    internal static Relation? Create(Supplement supplement)
    {
        var type = typeof(TRecord);

        var port = type.GetCustomAttributes<PortAttribute>().BySupplement(supplement);
        var icao = type.GetCustomAttributes<IcaoAttribute>().BySupplement(supplement);

        List<Link<TRecord>> links = [];

        List<Aggregation> aggregation = [];

        foreach (var property in type.GetProperties())
        {
            if (property.PropertyType == typeof(Ground.Port))
            {
                links.Add(port!.GetLink<TRecord>(property, supplement, icao!, null));
                continue;
            }

            var link = property.GetCustomAttributes<LinkAttribute>().BySupplement(supplement);

            if (link is not null)
            {
                links.Add(link.GetLink<TRecord>(property, supplement, icao, port));
            }
            else if (property.DeclaringType == type && property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                aggregation.Add(Aggregation.Create(property));
            }
        }
        return links.Count == 0 && aggregation.Count == 0 ? null : new Relation<TRecord>([.. links])
        {
            aggregations = [.. aggregation]
        };
    }

    internal override void Link(Queue<Build> builds, Unique unique, Meta424 meta)
    {
        Queue<Diagnostic> diagnostics = [];

        foreach (var build in (IEnumerable<Build<TRecord>>)builds) /* guarantee by design */
        {
            foreach (var link in links)
            {
                if (!link.TryLink(build.Record, unique, out var diagnostic))
                    diagnostics.Enqueue(diagnostic);
            }

            if (diagnostics.Count != 0)
            {
                build.Diagnostics ??= [];
                build.Diagnostics.Pump(diagnostics);
            }
        }
    }

    internal override Link[] Links => links;
}
