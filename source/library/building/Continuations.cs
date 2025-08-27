using System.Collections.Frozen;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace Arinc424.Building;

internal class Continuations
{
    private int index;
#pragma warning disable CS8618
    private Dictionary<ContinuationAttribute, Queue<string>> continuations;

    private FrozenDictionary<ContinuationAttribute, ContinuationInfo> info;

    private FrozenDictionary<ContinuationAttribute, PropertyInfo> properties;
#pragma warning restore CS8618
    internal static Continuations? Create(Type low, Type top, Supplement supplement)
    {
        var continuous = top.GetCustomAttributes<ContinuousAttribute>().BySupplement(supplement);

        if (continuous is null)
            return null;

        Dictionary<ContinuationAttribute, ContinuationInfo> info = [];
        Dictionary<ContinuationAttribute, PropertyInfo> properties = [];

        Dictionary<ContinuationAttribute, Queue<string>> continuations = [];

        foreach (var property in low.GetProperties())
        {
            if (property.GetCustomAttribute<ContinueAttribute>() is null)
                continue;

            var continuation = property.PropertyType.GetElementType()!.GetCustomAttribute<ContinuationAttribute>()!;

            info[continuation] = ContinuationInfo.Create((properties[continuation] = property).PropertyType.GetElementType()!, supplement);

            continuations[continuation] = [];
        }
        return new Continuations()
        {
            info = info.ToFrozenDictionary(),
            properties = properties.ToFrozenDictionary(),
            continuations = continuations,
            index = continuous.Index
        };
    }

    private bool TryMatch(string @string, [NotNullWhen(true)] out ContinuationAttribute? continuation)
    {
        foreach (var (attribute, _) in info)
        {
            if (attribute.IsMatch(@string))
            {
                continuation = attribute;
                return true;
            }
        }
        continuation = null;
        return false;
    }

    internal bool TryHold(string @string)
    {
        if (@string[index] <= '1')
            return false;

        if (TryMatch(@string, out var continuation))
            continuations[continuation].Enqueue(@string);

        return true;
    }

    internal void Process(Record424 record)
    {
        foreach (var (continuation, @strings) in continuations)
        {
            var builds = info[continuation].Build(strings);

            if (builds.Count == 0)
                continue;

            var property = properties[continuation];

            var array = Array.CreateInstance(property.PropertyType.GetElementType()!, builds.Count);

            int i = 0;
            foreach (var build in builds)
                array.SetValue(build.Record, i++);

            property.SetValue(record, array);
        }
    }
}
