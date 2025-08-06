using System.Reflection;

namespace Arinc424.Linking;

using Building;

internal abstract class BackLink(PropertyInfo property)
{
    protected PropertyInfo property = property;

    internal Type Type { get; } = property.PropertyType.GetElementType()!;

    internal abstract void Link(IEnumerable<Build> one, IEnumerable<Build> many);

    internal static BackLink Create(PropertyInfo property)
    {
        var type = typeof(BackLink<,>).MakeGenericType(property.DeclaringType!, property.PropertyType.GetElementType()!);

        return (BackLink)Activator.CreateInstance(type, property)!;
    }
}

internal sealed class BackLink<TOne, TMany>(PropertyInfo property) : BackLink(property)
    where TOne : Record424
    where TMany : Record424
{
    private static bool IsTargetProperty(PropertyInfo x) => (x.PropertyType == typeof(TOne)
        || x.PropertyType == typeof(Ground.Port)) && x.GetCustomAttribute<LinkAttribute>() is not null;

    private readonly Func<TMany, TOne> get =
        typeof(TMany).GetProperties().First(IsTargetProperty)
            .GetGetMethod()!.CreateDelegate<Func<TMany, TOne>>();

    private readonly Action<TOne, TMany[]> set =
        property.GetSetMethod()!.CreateDelegate<Action<TOne, TMany[]>>();

    internal override void Link(IEnumerable<Build> builds, IEnumerable<Build> others)
    {
        var one = (IEnumerable<Build<TOne>>)builds; /* guarantee by design */
        var many = (IEnumerable<Build<TMany>>)others; /* guarantee by design */

        Dictionary<TOne, Queue<TMany>> buffer = [];

        foreach (var @object in many)
        {
            var related = get(@object.Record);

            if (related is null)
                continue;

            if (!buffer.TryGetValue(related, out var stored))
                stored = buffer[related] = [];

            stored.Enqueue(@object.Record);
        }

        foreach (var @object in one)
        {
            if (buffer.TryGetValue(@object.Record, out var related))
                set(@object.Record, [.. related]);
        }
    }
}
