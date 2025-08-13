using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

internal abstract class Aggregation(PropertyInfo property)
{
    protected PropertyInfo property = property;

    internal Type Type { get; } = property.PropertyType.GetElementType()!;

    internal abstract void Aggregate(Queue<Build> one, Queue<Build> many);

    internal static Aggregation Create(PropertyInfo property)
    {
        var attr = property.GetCustomAttribute<ManyAttribute>();

        Type one = property.DeclaringType!, many = property.PropertyType.GetElementType()!;

        var back = many.GetProperty(attr!.Property);

        if (property.DeclaringType! != back!.PropertyType && one.IsSubclassOf(back.PropertyType))
            one = back.PropertyType!;

        var type = typeof(Aggregation<,>).MakeGenericType(one, many);

        return (Aggregation)Activator.CreateInstance(type, property, back)!;
    }
}

internal sealed class Aggregation<TOne, TMany>(PropertyInfo property, PropertyInfo back) : Aggregation(property)
    where TOne : Record424
    where TMany : Record424
{
    private readonly Func<TMany, TOne> get = back.GetGetMethod()!.CreateDelegate<Func<TMany, TOne>>();

    private readonly Action<TOne, TMany[]> set =
        property.GetSetMethod()!.CreateDelegate<Action<TOne, TMany[]>>();

    internal override void Aggregate(Queue<Build> builds, Queue<Build> others)
    {
        if (builds.Count == 0 || others.Count == 0)
            return;

        var one = Unsafe.As<Queue<Build<TOne>>>(builds); /* guarantee by design */
        var many = Unsafe.As<Queue<Build<TMany>>>(others); /* guarantee by design */

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
