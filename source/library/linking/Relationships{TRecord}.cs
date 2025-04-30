using System.Collections.Frozen;
using System.Reflection;

using Arinc424.Building;
using Arinc424.Diagnostics;

namespace Arinc424.Linking;

internal abstract class Relationships(Type type)
{
#pragma warning disable CS8618
    protected FrozenDictionary<Type, PropertyInfo> many;
#pragma warning restore CS8618
    internal abstract void Link(IEnumerable<Build> builds, Unique unique, Meta424 meta);

    internal void Process<TRecord>(Record424 self, TRecord referenced) where TRecord : Record424
    {
        var type = typeof(TRecord);

        // todo: compiled one & many relations
        if (many.TryGetValue(type, out var property))
        {
            if (property.GetValue(self) is not List<TRecord> value)
                property.SetValue(self, value = []);

            value.Add(referenced);
        }
    }

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

        foreach (var build in (IEnumerable<Build<TRecord>>)builds)
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
        List<Link<TRecord>> links = [];

        Dictionary<Type, PropertyInfo> one = [], many = [];

        foreach (var property in typeof(TRecord).GetProperties())
        {
            var identifier = property.GetCustomAttributes<IdentifierAttribute>().BySupplement(supplement);

            if (identifier is not null)
            {
                links.Add(identifier.GetLink<TRecord>(property, supplement));
            }
            else if (property.GetCustomAttribute<ManyAttribute>() is not null)
            {
                many[property.PropertyType.GetElementType()!] = property;
            }
        }
        return links is [] && one.Count == 0 && many.Count == 0 ? null : new Relationships<TRecord>([.. links])
        {
            many = many.ToFrozenDictionary()
        };
    }
}
