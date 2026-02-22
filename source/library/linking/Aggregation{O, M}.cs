using System.Reflection;
using System.Runtime.CompilerServices;

namespace Arinc424.Linking;

internal abstract class Aggregation(PropertyInfo property)
{
    protected PropertyInfo property = property;

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

    internal Type Type { get; } = property.PropertyType.GetElementType()!;
}

internal sealed class Aggregation<O, M>(PropertyInfo property, PropertyInfo back)
    : Aggregation(property)
        where O : Record424
        where M : Record424
{
    private readonly Func<M, O> get = back.GetGetMethod()!.CreateDelegate<Func<M, O>>();

    private readonly Action<O, M[]> set =
        property.GetSetMethod()!.CreateDelegate<Action<O, M[]>>();

    internal override void Aggregate(Queue<Build> builds, Queue<Build> others)
    {
        if (builds.Count == 0 || others.Count == 0)
            return;

        /* guarantee by design */
        var one = Unsafe.As<Queue<Build<O>>>(builds);
        var many = Unsafe.As<Queue<Build<M>>>(others);

        Dictionary<O, Queue<M>> buffer = [];

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
